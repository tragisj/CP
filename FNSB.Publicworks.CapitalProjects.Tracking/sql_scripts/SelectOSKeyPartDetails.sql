/*
Script created by SQL Prompt version 9.0.9.3951 from Red Gate Software Ltd at 3/23/2018 4:41:49 PM
Run this script to create the encapsulated stored procedure.

Please back up your database before running this script.
*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.SelectOSKeyPartDetails

@GLkey VARCHAR(10)

AS
BEGIN

	BEGIN

	DECLARE @TEMP TABLE (PartNo CHAR(2),
						PartValue VARCHAR(50),
						GroupId VARCHAR(4),
						GroupName VARCHAR(50),
						GroupLongDesc VARCHAR(50));

	INSERT INTO @TEMP
	SELECT '01' AS 'PartNo',
		   km.glk_grp_part01 AS 'PartValue',
		   gm.glk_grp_id AS 'GroupId',
		   'Fund Group' AS 'GroupDesc',
		   gm.glk_grp_dl AS 'GroupLongDesc'
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part01
	 WHERE gm.glk_grp_id = 'FGRP'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '02' AS 'PartNo',
		   km.glk_grp_part02 AS 'PartValue',
		   gm.glk_grp_id AS 'GroupId',
		   'Fund' AS 'GroupDesc',
		   gm.glk_grp_dl AS 'GroupLongDesc'
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part02
	 WHERE gm.glk_grp_id = 'FUND'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '03' AS 'PartNo',
		   km.glk_grp_part03,
		   gm.glk_grp_id,
		   'Function' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM[OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part03
	 WHERE gm.glk_grp_id = 'FUNC'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '04' AS 'PartNo',
		   km.glk_grp_part04,
		   gm.glk_grp_id,
		   'Funding Agency' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part04
	 WHERE gm.glk_grp_id = 'AGCY'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;



	INSERT INTO @TEMP
	SELECT '05' AS 'PartNo',
		   km.glk_grp_part05,
		   gm.glk_grp_id,
		   'Department' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part05
	 WHERE gm.glk_grp_id = 'DEPT'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '06' AS 'PartNo',
		   km.glk_grp_part06,
		   gm.glk_grp_id,
		   'Division' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM[OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part06
	 WHERE gm.glk_grp_id = 'DIVN'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '07' AS 'PartNo',
		   km.glk_grp_part07,
		   gm.glk_grp_id,
		   'Section/SVC Area' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part07
	 WHERE gm.glk_grp_id = 'SECT'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	INSERT INTO @TEMP
	SELECT '08' AS 'PartNo',
		   km.glk_grp_part08,
		   gm.glk_grp_id,
		   'Sub Section' AS 'GroupDesc',
		   gm.glk_grp_dl
	  FROM [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].[glk_grp_mstr] gm
	 INNER JOIN [OSBAC-SQLPROJ01\PROJ_OSFNSB].[Project_Finance].[dbo].glk_key_mstr km
		ON gm.glk_grp = km.glk_grp_part08
	 WHERE gm.glk_grp_id = 'SUBS'
	   AND gm.glk_grp_gr = 'GL'
	   AND km.glk_key    = @GlKey;


	SELECT *
	  FROM @TEMP;


END
END

GO
