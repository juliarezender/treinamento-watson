dotnet tool install –global dotnet-sonarscanner
dotnet sonarscanner begin /k:"TreinamentoWatson"/d:sonar.cs.opencover.reportsPaths="%CD%\opencover.xml"
dotnet build C:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\TreinamentoWatson.sln