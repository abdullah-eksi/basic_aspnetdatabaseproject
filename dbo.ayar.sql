CREATE TABLE [dbo].[ayar] (
    [id]               INT           NOT NULL,
    [ayar_tittle]      VARCHAR (50)  NOT NULL,
    [ayar_description] VARCHAR (100) NOT NULL,
    [ayar_keywords]    VARCHAR (50)  NOT NULL,
    [ayar_author]      VARCHAR (50)  NOT NULL,
    [ayar_insta]       VARCHAR (250) NOT NULL,
    [ayar_google]      VARCHAR (250) NOT NULL,
    [ayar_youtube]     VARCHAR (250) NOT NULL,
    [ayar_twitter]     VARCHAR (250) NOT NULL,
    [ayar_mail]        VARCHAR (250) NOT NULL,
    [ayar_tel]         VARCHAR (50)  NOT NULL,
    [ayar_konum]       VARCHAR (100) NOT NULL,
    [ayar_resimbir] VARCHAR(500) NOT NULL, 
    [ayar_resimiki] VARCHAR(500) NOT NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC)
);

