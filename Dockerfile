FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG DATABASESERVER
ARG DATABASENAME
ARG DATABASEPORT
ARG DATABASEUSER
ARG DATABASEPASSWORD

ENV DATABASESERVER $DATABASESERVER
ENV DATABASENAME $DATABASENAME
ENV DATABASEPORT $DATABASEPORT
ENV DATABASEUSER $DATABASEUSER
ENV DATABASEPASSWORD $DATABASE__PASSWORD

WORKDIR /App

ENV PATH=$PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef

COPY . ./

RUN dotnet restore cp-02.sln

RUN dotnet publish cp-02.sln -c Release -o out


RUN groupadd -r appuser && useradd -r -g appuser -m appuser

USER appuser
ENV PATH=$PATH:/home/appuser/.dotnet/tools
RUN dotnet tool install --global dotnet-ef


USER root

WORKDIR /App/out

RUN chown -R appuser:appuser /App/out

EXPOSE 8080
EXPOSE 8081

USER appuser

ENTRYPOINT ["dotnet", "challenge.dll"]