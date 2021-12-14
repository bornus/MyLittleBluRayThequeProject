-- Table: BluRayTheque.BluRayLangue

-- DROP TABLE IF EXISTS "BluRayTheque"."BluRayLangue";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."BluRayLangue"
(
    "Id" integer NOT NULL DEFAULT nextval('"BluRayTheque"."BluRayLangue_Id_seq"'::regclass),
    "IdBluRay" integer NOT NULL,
    "IdLangue" integer NOT NULL,
    CONSTRAINT "BluRayLangueIdBluRay" FOREIGN KEY ("IdBluRay")
        REFERENCES "BluRayTheque"."BluRay" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "BluRayLangueIdLangue" FOREIGN KEY ("IdLangue")
        REFERENCES "BluRayTheque"."RefLangue" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."BluRayLangue"
    OWNER to postgres;