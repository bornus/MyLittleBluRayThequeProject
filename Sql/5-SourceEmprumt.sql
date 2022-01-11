-- Table: BluRayTheque.SourceEmprunt

-- DROP TABLE IF EXISTS "BluRayTheque"."SourceEmprunt";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."SourceEmprunt"
(
    "Id" SERIAL NOT NULL,
    "Nom" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "baseUrl" character varying(200) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "SourceEmprunt_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."SourceEmprunt"
    OWNER to postgres;