FROM mcr.microsoft.com/dotnet/sdk:6.0
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef

WORKDIR /src
COPY . .
COPY ["API/AgilleApi.API.csproj", "API/"]
COPY ["Domain/AgilleApi.Domain.csproj", "Domain/"]
COPY ["Data/AgilleApi.Data.csproj", "Data/"]
RUN dotnet restore "API/AgilleApi.API.csproj"
RUN dotnet restore "Data/AgilleApi.Data.csproj"
