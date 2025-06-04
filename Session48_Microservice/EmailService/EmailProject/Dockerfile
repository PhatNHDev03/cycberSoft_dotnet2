FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

#tạo folder chứa source code
WORKDIR /app

#EXpose port ra ngoài thường là 80
EXPOSE 80

ENV ASPNETCORE_URLS=http://+80

#build stage builde để tạo thư mục build các dependencies --> thằng này có tác dụng 
#là khi ta build image thì nó sẽ tự động tải về các dependencies cần thiết để chạy ứng dụng cho thằng
# base ở trên sửa dụng
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

#copy file csproj vào thư mục src docker
# file này sẽ được sử dụng để tải về các dependencies cần thiết(Quan trọng cảu project)
# tương tự file pom.xml của maven, package.json của npm
# bên trái là thư mục chứa source code của project local
# bên phải là thư mục trong docker
COPY EmailProject.csproj ./EmailService/
# đảm bảo rằng thư mục này được cài đặt trước khi build
RUN dotnet restore ./EmailService/EmailProject.csproj
#copy toàn bộ source local vào thư mục src trong docker
COPY . ./EmailService/

#build project
WORKDIR /src/EmailService
RUN dotnet build "EmailProject.csproj" -c Release -o /app/build

#publish project để deploy
FROM build AS publish
RUN dotnet publish "EmailProject.csproj" -c Release -o /app/publish -p:UseAppHost=false

#final stage để chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "EmailProject.dll" ]