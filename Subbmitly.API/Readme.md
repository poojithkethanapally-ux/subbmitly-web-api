
Scaffolding Command
dotnet ef dbcontext scaffold "Server=POOJTHS-LAPTOP\SQLEXPRESS;Database=RecruitMgmt;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer `
>>   --project "C:\Users\pooji\Desktop\Projects\Subbmitly.API\Subbmitly.Domain\Subbmitly.Domain.csproj" `
>>   --startup-project "C:\Users\pooji\Desktop\Projects\Subbmitly.API\Subbmitly.API\Subbmitly.API.csproj" `
>>   --output-dir "Entities" `
>>   --context-dir "..\Subbmitly.Infrastructure" `
>>   --context RecruitMgmtDbContext `
>>   --data-annotations `
>>   --force