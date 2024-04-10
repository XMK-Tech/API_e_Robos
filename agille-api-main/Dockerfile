#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API/AgilleApi.API.csproj", "API/"]
COPY ["Domain/AgilleApi.Domain.csproj", "Domain/"]
COPY ["Data/AgilleApi.Data.csproj", "Data/"]
RUN dotnet restore "API/AgilleApi.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "AgilleApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgilleApi.API.csproj" -c Release -o /app/publish

FROM base AS final
RUN ["apt-get", "update"]
RUN ["apt-get", "-y", "install", "libgdiplus"]
RUN ["apt-get", "-y", "install", "xvfb", "libfontconfig", "wkhtmltopdf"]
RUN ["apt-get", "-y", "install", "libc6-dev"]
RUN ["apt-get", "-y", "install", "openssl"]
RUN ["apt-get", "-y", "install", "libssl1.1"]
RUN ["apt-get", "-y", "install", "xfonts-75dpi", "xfonts-base", "gvfs", "colord", "glew-utils", "libvisual-0.4-plugins", "gstreamer1.0-tools", "opus-tools", "qt5-image-formats-plugins", "qtwayland5", "qt5-qmltooling-plugins", "librsvg2-bin", "lm-sensors"]
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /src/API/libwkhtmltox.dll libwkhtmltox.dll
COPY --from=publish /src/API/libwkhtmltox.so libwkhtmltox.so
COPY --from=publish /src/API/libwkhtmltox.dylib libwkhtmltox.dylib

CMD ASPNETCORE_URLS=http://*:$PORT dotnet AgilleApi.API.dll
