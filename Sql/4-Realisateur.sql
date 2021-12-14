-- Table: BluRayTheque.Realisateur

-- DROP TABLE IF EXISTS "BluRayTheque"."Realisateur";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."Realisateur"
(
    "Id" integer NOT NULL DEFAULT nextval('"BluRayTheque"."Realisateur_Id_seq"'::regclass),
    "IdBluRay" integer NOT NULL,
    "IdRealisateur" integer,
    CONSTRAINT "Realisateur_pkey" PRIMARY KEY ("IdBluRay"),
    CONSTRAINT "RealisateurIdBluRay" FOREIGN KEY ("IdBluRay")
        REFERENCES "BluRayTheque"."BluRay" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "RealisateurIdPersonne" FOREIGN KEY ("IdRealisateur")
        REFERENCES "BluRayTheque"."Personne" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."Realisateur"
    OWNER to postgres;