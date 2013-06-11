ALTER DATABASE DHHH
SET SINGLE_USER WITH
ROLLBACK IMMEDIATE
RESTORE DATABASE DHHH
FROM DISK = 'E:\Documents\Projects\Database\EducationSolutionSoft.bak'
WITH MOVE 'DHHH' TO 'E:\Documents\Projects\Database\EducationSolutionSoft_Data.mdf',
MOVE 'DHHH_Log' TO 'E:\Documents\Projects\Database\EducationSolutionSoft_Log.ldf',
REPLACE
/*
Replace ... with Location of backup file
*/