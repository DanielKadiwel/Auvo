﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Estado" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "UF" text NOT NULL,
    CONSTRAINT "PK_Estado" PRIMARY KEY ("Id")
);

CREATE TABLE "Cidade" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" text NOT NULL,
    "EstadoId" integer NOT NULL,
    CONSTRAINT "PK_Cidade" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Cidade_Estado_EstadoId" FOREIGN KEY ("EstadoId") REFERENCES "Estado" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PrevisaoClima" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "CidadeId" integer NOT NULL,
    "DataPrevisao" timestamp with time zone NOT NULL,
    "Clima" text NOT NULL,
    "TemperaturaMinima" integer NOT NULL,
    "TemperaturaMaxima" integer NOT NULL,
    CONSTRAINT "PK_PrevisaoClima" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PrevisaoClima_Cidade_CidadeId" FOREIGN KEY ("CidadeId") REFERENCES "Cidade" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Cidade_EstadoId" ON "Cidade" ("EstadoId");

CREATE INDEX "IX_PrevisaoClima_CidadeId" ON "PrevisaoClima" ("CidadeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221024183113_initial', '6.0.10');

COMMIT;
