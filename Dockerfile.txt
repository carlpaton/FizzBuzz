# Build image
FROM microsoft/dotnet:2.0-sdk as builder 
WORKDIR /app  
COPY ./*.sln ./

# Copy all the csproj files and restore
COPY /*.csproj ./
RUN dotnet restore

COPY ./*.cs ./

RUN dotnet build -c Release --no-restore

RUN dotnet publish -c Release -o out

#Build the app image
FROM microsoft/aspnetcore:2.0  
WORKDIR /app  
ENV ASPNETCORE_ENVIRONMENT Local  
ENTRYPOINT ["dotnet", "FizzBuzz.dll"] 
COPY --from=builder /app/out .