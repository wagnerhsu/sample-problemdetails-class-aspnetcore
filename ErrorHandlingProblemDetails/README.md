## 2021-12-07
- 由于无法处理前端"yyyy-MM-dd HH:mm:ss"这样的时间格式，所以可以改用Newtonsoft.Json
- 也可以使用`AddJsonOptions`并定义`JsonConverter`来解决上述时间格式问题
- Add `IDesignTimeDbContextFactory` support
- Add async support
- Add an ActionFilter `ValidateCompanyExistAttribute`

## 2021-12-03
- Can persist to sqlserver

## 2021-12-02

- Create this file based on .NET 6.0
- Add Serilog support
- General ProblemDetails support
- Add Put and Delete feature

```powershell
.\ErrorHandlingProblemDetails.exe --urls=https://localhost:7299
```