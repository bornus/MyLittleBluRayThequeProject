ALTER TABLE IF EXISTS "BluRayTheque"."BluRay"
    ADD CONSTRAINT "Proprietaire_fkey" FOREIGN KEY ("Proprietaire")
    REFERENCES "BluRayTheque"."SourceEmprunt" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;