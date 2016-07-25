/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------*/

:r .\Common\PostDeployment\01.DomainValue.sql
:r .\Common\PostDeployment\02.EntityLifecycle.sql
:r .\Common\PostDeployment\03.EntityType.sql
:r .\Common\PostDeployment\04.EntityState.sql
:r .\Common\PostDeployment\05.EntityTransition.sql
:r .\Common\PostDeployment\06.EntityInfo.sql
:r .\Common\PostDeployment\07.Account.sql
:r .\Common\PostDeployment\08.TranslationCode.sql
:r .\Common\PostDeployment\09.Translation.English.sql
:r .\Common\PostDeployment\09.Translation.Ukraine.sql
:r .\Common\TestData\TestData.sql