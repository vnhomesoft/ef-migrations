DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'myapp') THEN
        CREATE SCHEMA myapp;
    END IF;
END $EF$;
CREATE TABLE IF NOT EXISTS myapp."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
        IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'myapp') THEN
            CREATE SCHEMA myapp;
        END IF;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
    CREATE TABLE myapp.students (
        id uuid NOT NULL,
        name text NULL,
        CONSTRAINT "PK_students" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
    CREATE TABLE myapp.subjects (
        id uuid NOT NULL,
        name text NULL,
        CONSTRAINT "PK_subjects" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
    CREATE TABLE myapp.student_subjects (
        student_id uuid NOT NULL,
        subject_id uuid NOT NULL,
        mark real NOT NULL,
        CONSTRAINT "PK_student_subjects" PRIMARY KEY (student_id, subject_id),
        CONSTRAINT "FK_student_subjects_students_student_id" FOREIGN KEY (student_id) REFERENCES myapp.students (id) ON DELETE CASCADE,
        CONSTRAINT "FK_student_subjects_subjects_subject_id" FOREIGN KEY (subject_id) REFERENCES myapp.subjects (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
    CREATE INDEX "IX_student_subjects_subject_id" ON myapp.student_subjects (subject_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM myapp."__EFMigrationsHistory" WHERE "MigrationId" = '20220910143516_InitialCreate') THEN
    INSERT INTO myapp."__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220910143516_InitialCreate', '6.0.8');
    END IF;
END $EF$;
COMMIT;

