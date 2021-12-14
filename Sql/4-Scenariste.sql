-- Table: BluRayTheque.Scenariste

-- DROP TABLE IF EXISTS "BluRayTheque"."Scenariste";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."Scenariste"
(
    "Id" SERIAL NOT NULL,
    "IdBluRay" integer NOT NULL,
    "IdScenariste" integer NOT NULL,
    CONSTRAINT "Scenariste_pkey" PRIMARY KEY ("IdBluRay"),
    CONSTRAINT "ScenaristeIdBluRay" FOREIGN KEY ("IdBluRay")
        REFERENCES "BluRayTheque"."BluRay" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "ScenaristeIdPersonne" FOREIGN KEY ("IdScenariste")
        REFERENCES "BluRayTheque"."Personne" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."Scenariste"
    OWNER to postgres;