ALTER DATABASE EducationSolutionSoft
SET SINGLE_USER WITH
ROLLBACK IMMEDIATE
RESTORE DATABASE EducationSolutionSoft
FROM DISK = '...\student-portal\Database\KinhTE.bak'
WITH MOVE 'EducationSolutionSoft_Data' TO '...\student-portal\Database\KinhTe_Data.mdf',
MOVE 'EducationSolutionSoft_Log' TO '...\student-portal\Database\KinhTe_Log.ldf',
REPLACE
/*
Replace ... with Location of backup file
*/