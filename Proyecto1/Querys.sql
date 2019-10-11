USE [BDAleaciones]
GO
/****** Object:  StoredProcedure [dbo].[iaDelLimit]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create PROCEDURE [dbo].[iaDelLimit] @idLimit int = 0
  As
  BEGIN
	BEGIN TRY

		DELETE FROM
					tabLimit
		WHERE
					idLimit		=	@idLimit


			-- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaDelUser]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[iaDelUser]
(
	@idUser				int
	,@User					int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		DELETE FROM
					catUsers
		WHERE
					idUser		=	@idUser

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaGetAllTime]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE procedure [dbo].[iaGetAllTime] @CategoryValue int = 1, @TimeBajo DateTime, @TimeAlto DateTime
	  as
		  Select distinct t.CategoryValue, t.TraceID, sd.SubgroupDateTime, ROW_NUMBER() OVER (ORDER BY sd.SubgroupDateTime DESC) AS Num from PROFICY_SPC_DATA.dbo.Trace as t
		  join PROFICY_SPC_DATA.dbo.SampleData as s on s.TraceID = t.TraceID
		  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
		  where t.CategoryName LIKE 'L%' and (CAST(REPLACE(CategoryValue, 'L', '') as int)) = @CategoryValue And sd.SubgroupDateTime BETWEEN @TimeBajo and @TimeAlto
		  order by sd.SubgroupDateTime desc;
GO
/****** Object:  StoredProcedure [dbo].[iaGetAllTimeEquipos]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE procedure [dbo].[iaGetAllTimeEquipos]  @TimeBajo DateTime, @TimeAlto DateTime, @TurnoBajo Time, @TurnoAlto Time
	  as
	  Begin
		IF @TurnoBajo < @TurnoAlto
		Begin
		  Select distinct t.CategoryValue, t.TraceID, sd.SubgroupDateTime, ROW_NUMBER() OVER (ORDER BY sd.SubgroupDateTime DESC) AS Num from PROFICY_SPC_DATA.dbo.Trace as t
		  join PROFICY_SPC_DATA.dbo.SampleData as s on s.TraceID = t.TraceID
		  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
		  where t.CategoryName LIKE 'L%' And sd.SubgroupDateTime BETWEEN @TimeBajo and @TimeAlto
		  and CAST(Sd.SubgroupDateTime as TIME) between @TurnoBajo and @TurnoAlto
			order by sd.SubgroupDateTime desc
			end
			else
			Begin
			Select distinct t.CategoryValue,T.CategoryName, t.TraceID, sd.SubgroupDateTime, ROW_NUMBER() OVER (ORDER BY sd.SubgroupDateTime DESC) AS Num from PROFICY_SPC_DATA.dbo.Trace as t
		  join PROFICY_SPC_DATA.dbo.SampleData as s on s.TraceID = t.TraceID
		  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
		  where t.CategoryName LIKE 'L%' And sd.SubgroupDateTime BETWEEN @TimeBajo and @TimeAlto
		  and cast(Sd.SubgroupDateTime as time) between cast(@TurnoBajo as time) and cast('23:59:59' as time)
			or 
		 cast(Sd.SubgroupDateTime as time) between cast('00:00:00' as time) and cast(@TurnoAlto as time)
			order by Sd.SubgroupDateTime desc
		  End
	End
		  --and CAST(Sd.SubgroupDateTime as TIME) between @TurnoBajo and @TurnoAlto
		 -- cast(Sd.SubgroupDateTime as time) between cast(@TurnoBajo as time) and cast('23:59:59' as time)
			--or 
		 --cast(Sd.SubgroupDateTime as time) between cast('00:00:00' as time) and cast(@TurnoAlto as time)
GO
/****** Object:  StoredProcedure [dbo].[iaGetAllTimeLingotes]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[iaGetAllTimeLingotes] @CategoryValue int = 1, @TimeBajo DateTime, @TimeAlto DateTime
  AS
  select t.TagIndex, t.DateAndTime from Calcio_FP as t where t.TagIndex = @CategoryValue and t.DateAndTime BETWEEN @TimeBajo and @TimeAlto
  Order by t.DateAndTime desc
GO
/****** Object:  StoredProcedure [dbo].[iaGetAllTimeLingotesEquipos]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[iaGetAllTimeLingotesEquipos] @TimeBajo DateTime, @TimeAlto DateTime, @TurnoBajo Time, @TurnoAlto Time
	  as
	  Begin
		IF @TurnoBajo < @TurnoAlto
		Begin
			 select t.TagIndex, t.DateAndTime from Calcio_FP as t where t.DateAndTime BETWEEN @TimeBajo and @TimeAlto
			 and CAST(t.DateAndTime as TIME) between @TurnoBajo and @TurnoAlto
			Order by t.DateAndTime desc
		end
		else
		begin
		select t.TagIndex, t.DateAndTime from Calcio_FP as t where t.DateAndTime BETWEEN @TimeBajo and @TimeAlto
		and cast(t.DateAndTime as time) between cast(@TurnoBajo as time) and cast('23:59:59' as time)
			or 
		 cast(t.DateAndTime as time) between cast('00:00:00' as time) and cast(@TurnoAlto as time)
		 Order by t.DateAndTime desc
		end
		end
GO
/****** Object:  StoredProcedure [dbo].[iaGetAnalisisFecha]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[iaGetAnalisisFecha] @CategoryValue int = 1
AS
	  Select distinct top 2 t.CategoryValue, t.TraceID, sd.SubgroupDateTime from PROFICY_SPC_DATA.dbo.Trace as t
	  join PROFICY_SPC_DATA.dbo.SampleData as s on s.TraceID = t.TraceID
	  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
	  where t.CategoryName LIKE 'L%' and (CAST(REPLACE(CategoryValue, 'L', '') as int)) = @CategoryValue
	  order by sd.SubgroupDateTime desc;
GO
/****** Object:  StoredProcedure [dbo].[iaGetAnalisisLingotesRecomendados]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[iaGetAnalisisLingotesRecomendados] @CategoryValue int = 1
	as
    select distinct top 1 sd.SubgroupDateTime, 
  c.CharacteristicName, t.CategoryValue,c.MathFormula from PROFICY_SPC_DATA.dbo.SampleData as s
   	  join PROFICY_SPC_DATA.dbo.Trace as t on s.TraceID = t.TraceID
	  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
	  join PROFICY_SPC_DATA.dbo.CharData as c on c.PartCharID = sd.PartCharID  where CharacteristicName LIKE 'Ling%' and
   (t.CategoryName LIKE 'L%' and (CAST(REPLACE(CategoryValue, 'L', '') as int)) = Cast(@CategoryValue AS CHAR(1)))
	order by sd.SubgroupDateTime desc, t.CategoryValue asc, c.CharacteristicName desc;
	
GO
/****** Object:  StoredProcedure [dbo].[iaGetAnalisisPorcentaje]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[iaGetAnalisisPorcentaje] @CategoryValue int = 1
	as
  select distinct top 3 sd.SubgroupDateTime, 
  Case when Sample not between LRL and URL then -9999 else Sample end as [Sample],
  c.CharacteristicName, t.CategoryValue, c.LRL,c.URL from PROFICY_SPC_DATA.dbo.SampleData as s
   	  join PROFICY_SPC_DATA.dbo.Trace as t on s.TraceID = t.TraceID
	  join PROFICY_SPC_DATA.dbo.SubgroupData as Sd on sd.SubgroupID = s.SubgroupID
	  join PROFICY_SPC_DATA.dbo.CharData as c on c.PartCharID = sd.PartCharID  where
   (t.CategoryName LIKE 'L%' and (CAST(REPLACE(CategoryValue, 'L', '') as int)) = Cast(@CategoryValue AS CHAR(1)))
	order by sd.SubgroupDateTime desc, t.CategoryValue asc, c.CharacteristicName desc;
GO
/****** Object:  StoredProcedure [dbo].[iaGetDiffTimeLingotes]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[iaGetDiffTimeLingotes] @CategoryValue int = 1
  AS
	  select t.TagIndex, t.DateAndTime, t.Val from Calcio_FP as t where t.TagIndex = @CategoryValue
	  Order by t.DateAndTime desc
GO
/****** Object:  StoredProcedure [dbo].[iaGetMaxLineas]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE procedure [dbo].[iaGetMaxLineas]
	AS
	Select Max((CAST(REPLACE(CategoryValue, 'L', '') as int))) as max from PROFICY_SPC_DATA.dbo.Trace where CategoryName Like 'L%' ;
GO
/****** Object:  StoredProcedure [dbo].[iaGetTurnos]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE procedure [dbo].[iaGetTurnos] 
	  as
		  Select distinct * from catTiemposCuadrilla;
GO
/****** Object:  StoredProcedure [dbo].[iaInsLimit]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[iaInsLimit] @NumValue decimal = 0.0, @createdBy int = 0
  As
  BEGIN
	BEGIN TRY

	Insert into tabLimit
	select @NumValue,
			@CreatedBy,
			GETDATE(),
			0,
			GETDATE()

			-- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaInsProfile]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[iaInsProfile]
(
	@descProfile				Varchar(20)
	,@createdBy				int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		INSERT INTO catProfile
		SELECT
					@descProfile
					,@createdBy
					,GETDATE()
					,null
					,Null

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaInsUser]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[iaInsUser]
(
	@namUser				Varchar(20)
	,@userPass				Varchar(20)
	,@idProfile				int
	,@createdBy				int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		INSERT INTO catUsers
		SELECT
					@namUser
					,@userPass
					,@idProfile
					,@createdBy
					,GETDATE()
					,null
					,Null

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaLRecomendados]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[iaLRecomendados] @Calcio float, @Estano float, @MathFormula nvarchar(255)
	as
	declare @result as float

	IF(@MathFormula like '%A%')
	Begin
		IF(@Calcio<0.065)
		Begin
			set @result = ((.065-@Calcio)/100*40000)/0.27
			return @result
			end
		ELSE
		begin
		set @result = 0
		return @result
		end
	end
	ELSE
	begin
			IF(@Estano<0.065)
			begin
				set @result = ((.065-@Estano)/100*40000)/0.27
				return @result
			end
			ELSE
			Begin
				set @result = 0
				return @result
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[iaSelLimit]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[iaSelLimit] @idLimit int = 0
  As
  BEGIN
	BEGIN TRY

		IF(@idLimit = 0)
			SELECT * FROM tabLimit
			order by idLimit desc

		ELSE
			SELECT * FROM tabLimit where idLimit = @idLimit

			-- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaSelProfile]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[iaSelProfile]
(
	@idProfile				int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		IF(@idProfile = 0)
			SELECT * FROM tabUserProfile

		ELSE
			SELECT * FROM tabUserProfile where idProfile = @idProfile

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaSelUser]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[iaSelUser]
(
	@idUser				int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		IF(@idUser = 0)
			SELECT * FROM catUsers

		ELSE
			SELECT * FROM catUsers where idUser = @idUser

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
/****** Object:  StoredProcedure [dbo].[iaSumaLingotes]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[iaSumaLingotes] @CategoryValue int = 1, @Date dateTime
	as
    select COALESCE(sum(Val),0) as Val from Calcio_FP where TagIndex = @CategoryValue and DateAndTime between  @Date and GETDATE()
	
GO
/****** Object:  StoredProcedure [dbo].[iaUpdUser]    Script Date: 6/13/2019 5:32:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[iaUpdUser]
(
	@idUser					int
	,@namUser				Varchar(20)
	,@userPass				Varchar(10)
	,@idProfile				int
	,@User					int
)
AS
BEGIN
	BEGIN TRY

		SET NOCOUNT ON;

		UPDATE
					catUsers
		SET
					namUser			=	@namUser
					,userPass		=	@userPass
					,idProfile		=	@idProfile
					,modifiedBy		=	@User
					,modifiedDate	=	GETDATE()
		WHERE
					idUser		=	@idUser

		 -- Everything processed correctly. 
		IF @@TRANCOUNT > 0
		BEGIN
			/** Commit Transaction**/
			COMMIT
		END
	END TRY

	BEGIN CATCH	

		/* Rollback Transaction*/
		ROLLBACK TRANSACTION
		
		--Declare Error variables
		DECLARE @ErrorMessage	NVARCHAR(4000);
		DECLARE @ErrorCode		INT;
		DECLARE @ErrorState		INT;

		--Set Error variables
		SELECT 
				@ErrorMessage	= ERROR_MESSAGE(),
				@ErrorState		= ERROR_STATE(),
				@ErrorCode		= @@ERROR;

		--Return Error Information
		RAISERROR(@ErrorMessage, @ErrorState, @ErrorCode);

	END CATCH
		 
END
GO
