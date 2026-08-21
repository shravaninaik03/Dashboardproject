//Total projects
create or replace function public.get_total_projects()
returns INTEGER
language plpgsql
AS $$
BEGIN
    RETURN (SELECT COUNT(*)::INTEGER
        FROM public."Projects");
END;
$$;

select count(*) from public.projects;

//Total tasks belonging toprojects

CREATE OR REPLACE FUNCTION "TF".get_total_tasks()
returns INTEGER
language plpgsql
AS $$
BEGIN
    RETURN (SELECT COUNT(*)::INTEGER
        FROM "TF"."Tasks" t
        INNER JOIN public."Projects" p
            ON t."EntityId" = p."Id"::text
        WHERE t."Entity" = 'PROJECT'
          AND t."IsDeleted" = false
          AND t."IsSystemTask" = false);
END;
$$;

select count(*) from tf.tasks;