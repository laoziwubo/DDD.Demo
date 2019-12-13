#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["DDD.Demo/DDD.Demo.csproj", "DDD.Demo/"]
RUN dotnet restore "DDD.Demo/DDD.Demo.csproj"
COPY . .
WORKDIR "/src/DDD.Demo"
RUN dotnet build "DDD.Demo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DDD.Demo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DDD.Demo.dll"]