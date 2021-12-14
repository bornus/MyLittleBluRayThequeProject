-- Table: BluRayTheque.RefLangue

-- DROP TABLE IF EXISTS "BluRayTheque"."RefLangue";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."RefLangue"
(
    "Id" SERIAL NOT NULL,
    "Langue" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "RefLangue_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."RefLangue"
    OWNER to postgres;