DELETE dbo.Extractions;
DELETE dbo.Drillings;
DELETE dbo.WellsEquipment;
DELETE dbo.AnalyzedWells;
DELETE dbo.Wells;
DELETE dbo.Sites;
DELETE dbo.Engineers;
DELETE dbo.Resources;
DELETE dbo.ResourceTypes;
DELETE dbo.Equipment;

INSERT INTO dbo.Sites ( SiteID ,
                        SiteName )
VALUES ( 1, 'Route 66' ) ,
       ( 2, 'Hanamura' ) ,
       ( 3, 'Numbani' );

INSERT INTO dbo.Wells ( WellId ,
                        WellName ,
                        SiteId )
VALUES ( 1, 'Alpha', 1 ) ,
       ( 2, 'Bravo', 1 ) ,
       ( 3, 'Charlie', 1 ) ,
       ( 4, 'Alpha', 2 ) ,
       ( 5, 'Bravo', 2 ) ,
       ( 6, 'Alpha', 3 ) ,
       ( 7, 'Bravo', 3 ) ,
       ( 8, 'Charlie', 3 ) ,
       ( 9, 'Delta', 3 );

INSERT INTO dbo.ResourceTypes ( ResourceTypeId ,
                                ResouceType )
VALUES ( 1, 'Oil' ) ,
       ( 2, 'Gas' );

INSERT INTO dbo.Engineers ( EngineerId ,
                            EngineerName ,
                            ResourceTypeId )
VALUES ( 1, 'Oil Engineer', 1 ) ,
       ( 2, 'Gas Engineer', 1 );

INSERT INTO dbo.Resources ( ResourceId ,
                            ResourceName ,
                            ResourceTypeId )
VALUES ( 1, 'Oil resouce', 1 ) ,
       ( 2, 'Gas resource', 2 );

INSERT INTO dbo.Equipment ( EquipmentId ,
                            EquipmentName )
VALUES ( 1, 'Extractors' ) ,
       ( 2, 'Storage Tanks' ) ,
       ( 3, 'Office Buildings' );


INSERT INTO dbo.WellsEquipment ( WellId ,
                                 EquipmentId )
            SELECT w.WellId ,
                   e.EquipmentId
            FROM   dbo.Wells                AS w
                   CROSS JOIN dbo.Equipment AS e;

INSERT INTO dbo.AnalyzedWells ( AnalyzedWellId ,
                                WellId ,
                                EngineerId ,
                                AnalizedOn ,
                                ResourceTypeId ,
                                Reserves )
VALUES ( 1, 1, 1, SYSDATETIME(), 1, 1500 ) ,
       ( 2, 2, 1, SYSDATETIME(), 1, 2500 ) ,
       ( 3, 2, 2, SYSDATETIME(), 2, 5000 ) ,
       ( 4, 3, 1, SYSDATETIME(), 1, 8000 ) ,
       ( 5, 3, 2, SYSDATETIME(), 2, 15000 ) ,
       ( 6, 4, 1, SYSDATETIME(), 1, 5000 ) ,
       ( 7, 4, 2, SYSDATETIME(), 2, 5000 ) ,
       ( 8, 5, 1, SYSDATETIME(), 1, 3000 ) ,
       ( 9, 5, 2, SYSDATETIME(), 2, 20000 ) ,
       ( 10, 6, 1, SYSDATETIME(), 1, 1000 ) ,
       ( 11, 6, 2, SYSDATETIME(), 2, 2500 ) ,
       ( 12, 7, 1, SYSDATETIME(), 1, 1500 ) ,
       ( 13, 7, 2, SYSDATETIME(), 2, 10000 ) ,
       ( 14, 8, 1, SYSDATETIME(), 1, 7500 ) ,
       ( 15, 8, 2, SYSDATETIME(), 2, 12500 ) ,
       ( 16, 9, 1, SYSDATETIME(), 1, 1650 ) ,
       ( 17, 9, 2, SYSDATETIME(), 2, 13500 );

INSERT INTO dbo.Drillings ( DrillingId ,
                            AnalyzedWellId )
            SELECT ROW_NUMBER() OVER ( ORDER BY aw.AnalyzedWellId ) AS DrillingId ,
                   aw.AnalyzedWellId
            FROM   dbo.AnalyzedWells AS aw;

INSERT INTO dbo.Extractions ( ExtractionId ,
                              DrillingId ,
                              EquipmentId ,
                              ResourceId ,
                              ExtractedAmount ,
                              ExtractionDate )
            SELECT ROW_NUMBER() OVER ( ORDER BY d.DrillingId )         AS ExtractionId ,
                   d.DrillingId ,
                   e.EquipmentId ,
                   r.ResourceId ,
                   RAND()                                              AS ExtractedAmount ,
                   DATEADD(DAY, ( ABS(CHECKSUM(NEWID())) % 65530 ), 0) AS ExtractionDate
            FROM   dbo.Drillings            AS d
                   CROSS JOIN dbo.Equipment AS e
                   CROSS JOIN dbo.Resources AS r;
