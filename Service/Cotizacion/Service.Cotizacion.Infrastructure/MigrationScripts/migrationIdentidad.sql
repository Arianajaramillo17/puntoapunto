IF OBJECT_ID(N'[crm].[__EFMigrationHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'crm') IS NULL EXEC(N'CREATE SCHEMA [crm];');
    CREATE TABLE [crm].[__EFMigrationHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    IF SCHEMA_ID(N'cotiza') IS NULL EXEC(N'CREATE SCHEMA [cotiza];');
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE TABLE [cotiza].[EstadosCotizaciones] (
        [EstadoCotizacionId] uniqueidentifier NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Codigo] nvarchar(max) NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_EstadosCotizaciones] PRIMARY KEY ([EstadoCotizacionId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE TABLE [cotiza].[TiposMateriales] (
        [TipoMaterialId] uniqueidentifier NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Codigo] nvarchar(max) NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_TiposMateriales] PRIMARY KEY ([TipoMaterialId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE TABLE [cotiza].[Cotizaciones] (
        [CotizacionId] uniqueidentifier NOT NULL,
        [Detalle] nvarchar(max) NOT NULL,
        [EstadoCotizacionId] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_Cotizaciones] PRIMARY KEY ([CotizacionId]),
        CONSTRAINT [FK_Cotizaciones_EstadosCotizaciones_EstadoCotizacionId] FOREIGN KEY ([EstadoCotizacionId]) REFERENCES [cotiza].[EstadosCotizaciones] ([EstadoCotizacionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE TABLE [cotiza].[MaterialesPrimarios] (
        [MaterialPrimarioId] uniqueidentifier NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [TipoMaterialId] uniqueidentifier NOT NULL,
        [Precio] float NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_MaterialesPrimarios] PRIMARY KEY ([MaterialPrimarioId]),
        CONSTRAINT [FK_MaterialesPrimarios_TiposMateriales_TipoMaterialId] FOREIGN KEY ([TipoMaterialId]) REFERENCES [cotiza].[TiposMateriales] ([TipoMaterialId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE TABLE [cotiza].[CotizacionesDetalles] (
        [CotizacionDetalleId] uniqueidentifier NOT NULL,
        [CotizacionId] uniqueidentifier NOT NULL,
        [MaterialPrimarioId] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Deleted] datetime2 NULL,
        CONSTRAINT [PK_CotizacionesDetalles] PRIMARY KEY ([CotizacionDetalleId]),
        CONSTRAINT [FK_CotizacionesDetalles_Cotizaciones_CotizacionId] FOREIGN KEY ([CotizacionId]) REFERENCES [cotiza].[Cotizaciones] ([CotizacionId]) ON DELETE CASCADE,
        CONSTRAINT [FK_CotizacionesDetalles_MaterialesPrimarios_MaterialPrimarioId] FOREIGN KEY ([MaterialPrimarioId]) REFERENCES [cotiza].[MaterialesPrimarios] ([MaterialPrimarioId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE INDEX [IX_Cotizaciones_EstadoCotizacionId] ON [cotiza].[Cotizaciones] ([EstadoCotizacionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE INDEX [IX_CotizacionesDetalles_CotizacionId] ON [cotiza].[CotizacionesDetalles] ([CotizacionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE INDEX [IX_CotizacionesDetalles_MaterialPrimarioId] ON [cotiza].[CotizacionesDetalles] ([MaterialPrimarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    CREATE INDEX [IX_MaterialesPrimarios_TipoMaterialId] ON [cotiza].[MaterialesPrimarios] ([TipoMaterialId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [crm].[__EFMigrationHistory] WHERE [MigrationId] = N'20240308024049_Initial0.0.1')
BEGIN
    INSERT INTO [crm].[__EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240308024049_Initial0.0.1', N'7.0.1');
END;
GO

COMMIT;
GO

