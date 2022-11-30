#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# First method

# FROM mcr.microsoft.com/dotnet/aspnet:6.0 
# WORKDIR /app
# COPY bin/Release/net6.0/publish /app/
# ENTRYPOINT ["dotnet","UdemyWebDocker.dll"]

# Second method (Because of using sdk image , image will get bigger)

# FROM mcr.microsoft.com/dotnet/sdk:6.0
# WORKDIR /app/
# COPY . .
# RUN dotnet restore
# RUN dotnet publish UdemyWebDocker.csproj -c Release -o out
# WORKDIR /out/
# ENV ASPNETCORE_URLS="http://*:4500"
# ENTRYPOINT [ "dotnet","UdemyWebDocker.dll" ]

# Third method (same size as first method but much faster)

FROM mcr.microsoft.com/dotnet/sdk:6.0 as base
WORKDIR /app/

COPY *.csproj .
RUN dotnet restore
COPY . .

RUN dotnet publish UdemyWebDocker.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=base /app/out/ .
ENV ASPNETCORE_URLS="http://*:4500"
ENTRYPOINT [ "dotnet","UdemyWebDocker.dll" ]