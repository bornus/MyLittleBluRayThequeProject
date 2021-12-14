-- Table: BluRayTheque.BluRaySsTitre

-- DROP TABLE IF EXISTS "BluRayTheque"."BluRaySsTitre";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."BluRaySsTitre"
(
    "Id" integer NOT NULL DEFAULT nextval('"BluRayTheque"."BluRaySsTitre_Id_seq"'::regclass),
    "IdBluRay" integer NOT NULL,
    "IdssTitreLangue" integer NOT NULL,
    CONSTRAINT "BluRaySsTitre_pkey" PRIMARY KEY ("IdBluRay"),
    CONSTRAINT "BluRaySsTitreIdBluRay" FOREIGN KEY ("IdBluRay")
        REFERENCES "BluRayTheque"."BluRay" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "BluRaySsTitreIdLangue" FOREIGN KEY ("IdssTitreLangue")
        REFERENCES "BluRayTheque"."RefLangue" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."BluRaySsTitre"
    OWNER to postgres;