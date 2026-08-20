//Total projects
create or replace function public.get_total_projects()
returns INTEGER
language plpgsql
AS $$
BEGIN
    RETURN (SELECT COUNT(*)::INTEGER
        FROM public.projects);
END;
$$;

select count(*) from public.projects;

//Total tasks belonging toprojects

create or replace function tf.get_total_tasks()
returns INTEGER
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN (SELECT COUNT(*)::INTEGER
        FROM tf.tasks t
        INNER JOIN public.projects p
            ON t."AppId" = p."ProjectId");
END;
$$;

select count(*) from tf.tasks;