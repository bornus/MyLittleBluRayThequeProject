-- Table: BluRayTheque.BluRay

-- DROP TABLE IF EXISTS "BluRayTheque"."BluRay";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."BluRay"
(
    "Id" SERIAL NOT NULL,
    "Titre" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Duree" integer,
    "DateSortie" date,
    "Version" character varying(100) COLLATE pg_catalog."default",
    "Emprunt" boolean,
    "Proprietaire" integer,
    "Disponible" boolean,
    CONSTRAINT "BluRay_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."BluRay"
    OWNER to postgres;