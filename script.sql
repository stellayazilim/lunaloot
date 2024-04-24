CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "ApplicationRoles" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Perms" text NOT NULL,
    CONSTRAINT "PK_ApplicationRoles" PRIMARY KEY ("Id")
);

CREATE TABLE "ApplicationUsers" (
    "Id" uuid NOT NULL,
    "FirstName" character varying(64) NOT NULL,
    "LastName" character varying(64) NOT NULL,
    "Email" character varying(64) NOT NULL,
    "PhoneNumber" character varying(11) NOT NULL,
    "Password" character varying(255) NOT NULL,
    CONSTRAINT "PK_ApplicationUsers" PRIMARY KEY ("Id")
);

CREATE TABLE "ApplicationRoleApplicationUser" (
    "RolesId" uuid NOT NULL,
    "UsersId" uuid NOT NULL,
    CONSTRAINT "PK_ApplicationRoleApplicationUser" PRIMARY KEY ("RolesId", "UsersId"),
    CONSTRAINT "FK_ApplicationRoleApplicationUser_ApplicationRoles_RolesId" FOREIGN KEY ("RolesId") REFERENCES "ApplicationRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ApplicationRoleApplicationUser_ApplicationUsers_UsersId" FOREIGN KEY ("UsersId") REFERENCES "ApplicationUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_ApplicationRoleApplicationUser_UsersId" ON "ApplicationRoleApplicationUser" ("UsersId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240422061759_Initial', '8.0.4');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240422072040_co', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "ApplicationUsers" ADD "Addresses" text NOT NULL DEFAULT '';

ALTER TABLE "ApplicationUsers" ADD "CreatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "ApplicationUsers" ADD "DeleteReason" text NOT NULL DEFAULT '';

ALTER TABLE "ApplicationUsers" ADD "DeletedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "ApplicationUsers" ADD "IsEmailVerified" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "ApplicationUsers" ADD "IsPhoneVerified" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "ApplicationUsers" ADD "LoginAttempts" smallint NOT NULL DEFAULT 0;

ALTER TABLE "ApplicationUsers" ADD "UpdatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "ApplicationUsers" ADD "VerificationCode" text;

ALTER TABLE "ApplicationRoles" ADD "CreatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "ApplicationRoles" ADD "DeleteReason" text NOT NULL DEFAULT '';

ALTER TABLE "ApplicationRoles" ADD "DeletedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "ApplicationRoles" ADD "UpdatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

CREATE TABLE "Addresses" (
    "Id" uuid NOT NULL,
    "Country" character varying(64) NOT NULL,
    "City" character varying(64) NOT NULL,
    "Province" character varying(64) NOT NULL,
    "Town" character varying(64) NOT NULL,
    "Street" character varying(64) NOT NULL,
    "PostCode" character varying(8) NOT NULL,
    "Name" character varying(64) NOT NULL,
    "Description" character varying(255) NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NOT NULL,
    "DeletedAt" timestamp with time zone NOT NULL,
    "DeleteReason" text NOT NULL,
    CONSTRAINT "PK_Addresses" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423033736_Address Table', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "ApplicationUsers" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.336404Z';

ALTER TABLE "ApplicationUsers" ALTER COLUMN "DeletedAt" DROP NOT NULL;

ALTER TABLE "ApplicationUsers" ALTER COLUMN "DeleteReason" DROP NOT NULL;

ALTER TABLE "ApplicationUsers" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.336387Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.335226Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "DeletedAt" DROP NOT NULL;

ALTER TABLE "ApplicationRoles" ALTER COLUMN "DeleteReason" DROP NOT NULL;

ALTER TABLE "ApplicationRoles" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.335204Z';

ALTER TABLE "Addresses" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.334295Z';

ALTER TABLE "Addresses" ALTER COLUMN "DeletedAt" DROP NOT NULL;

ALTER TABLE "Addresses" ALTER COLUMN "DeleteReason" DROP NOT NULL;

ALTER TABLE "Addresses" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T04:31:47.334272Z';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423043147_date time columns', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "ApplicationUsers" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.040981Z';

ALTER TABLE "ApplicationUsers" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.040954Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.039742Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "Name" TYPE character varying(64);

ALTER TABLE "ApplicationRoles" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.03972Z';

ALTER TABLE "ApplicationRoles" ADD "Weight" smallint NOT NULL DEFAULT 0;

ALTER TABLE "Addresses" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.038741Z';

ALTER TABLE "Addresses" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:15:15.038717Z';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423161515_Role perm update', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "ApplicationUsers" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.952102Z';

ALTER TABLE "ApplicationUsers" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.952085Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.951022Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.951005Z';

ALTER TABLE "Addresses" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.950168Z';

ALTER TABLE "Addresses" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T16:42:52.95015Z';

CREATE UNIQUE INDEX "IX_ApplicationUsers_Email" ON "ApplicationUsers" ("Email");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423164253_user unique email', '8.0.4');

COMMIT;

START TRANSACTION;

DROP TABLE "ApplicationRoleApplicationUser";

ALTER TABLE "ApplicationUsers" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.169254Z';

ALTER TABLE "ApplicationUsers" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.169234Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.16843Z';

ALTER TABLE "ApplicationRoles" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.168407Z';

ALTER TABLE "ApplicationRoles" ADD "ApplicationUserId" uuid;

ALTER TABLE "Addresses" ALTER COLUMN "UpdatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.168005Z';

ALTER TABLE "Addresses" ALTER COLUMN "CreatedAt" SET DEFAULT TIMESTAMPTZ '2024-04-23T19:05:06.16798Z';

CREATE INDEX "IX_ApplicationRoles_ApplicationUserId" ON "ApplicationRoles" ("ApplicationUserId");

ALTER TABLE "ApplicationRoles" ADD CONSTRAINT "FK_ApplicationRoles_ApplicationUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "ApplicationUsers" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240423190506_remove users from roles', '8.0.4');

COMMIT;

