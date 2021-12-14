-- Table: BluRayTheque.Personne

-- DROP TABLE IF EXISTS "BluRayTheque"."Personne";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."Personne"
(
    "Id" SERIAL NOT NULL,
    "Nom" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Prenom" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "DateNaissance" date,
    "Nationalite" character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT "Personne_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."Personne"
    OWNER to postgres;
