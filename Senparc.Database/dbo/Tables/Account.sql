﻿CREATE TABLE [dbo].[Account] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [ParentAccountId]      INT             NULL,
    [ParentIsKF]           BIT             CONSTRAINT [DF_Account_ParentIsKF] DEFAULT ((0)) NOT NULL,
    [UserName]             VARCHAR (50)    NOT NULL,
    [Password]             VARCHAR (50)    NOT NULL,
    [PasswordSalt]         VARCHAR (50)    NOT NULL,
    [NickName]             NVARCHAR (50)   NULL,
    [RealName]             NVARCHAR (50)   NULL,
    [Tel]                  VARCHAR (50)    NULL,
    [Email]                VARCHAR (150)   NULL,
    [EmailChecked]         BIT             NOT NULL,
    [Phone]                VARCHAR (20)    NOT NULL,
    [PhoneChecked]         BIT             NOT NULL,
    [WeixinOpenId]         VARCHAR (100)   NULL,
    [PicUrl]               VARCHAR (200)   NULL,
    [HeadImgUrl]           VARCHAR (200)   NULL,
    [Package]              DECIMAL (18, 2) CONSTRAINT [DF_Account_Package] DEFAULT ((0)) NOT NULL,
    [Balance]              DECIMAL (18, 2) CONSTRAINT [DF_Account_Balance] DEFAULT ((0)) NOT NULL,
    [LockMoney]            DECIMAL (18, 2) CONSTRAINT [DF_Account_LockMoney] DEFAULT ((0)) NOT NULL,
    [Sex]                  TINYINT         NOT NULL,
    [QQ]                   VARCHAR (50)    NULL,
    [Country]              NVARCHAR (20)   NULL,
    [Province]             NVARCHAR (20)   NULL,
    [City]                 NVARCHAR (20)   NULL,
    [District]             NVARCHAR (20)   NULL,
    [Address]              NVARCHAR (250)  NULL,
    [Note]                 NTEXT           NULL,
    [Type]                 INT             CONSTRAINT [DF_Account_Type] DEFAULT ((0)) NOT NULL,
    [ThisLoginTime]        DATETIME        NOT NULL,
    [ThisLoginIP]          VARCHAR (50)    NULL,
    [LastLoginTime]        DATETIME        NOT NULL,
    [LastLoginIP]          VARCHAR (50)    NULL,
    [AddTime]              DATETIME        NOT NULL,
    [Points]               DECIMAL (18, 2) NOT NULL,
    [LastWeixinSignInTime] DATETIME        NULL,
    [WeixinSignTimes]      INT             NOT NULL,
    [Wallet]               DECIMAL (18, 2) CONSTRAINT [DF_Account_Wallet] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Account_Account1] FOREIGN KEY ([ParentAccountId]) REFERENCES [dbo].[Account] ([Id])
);

