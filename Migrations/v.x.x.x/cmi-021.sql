declare
   l_nullable user_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from user_tab_columns 
  where table_name = 'INSPECTOR_PROFILE_REFERRAL_GROUP' 
  and column_name = 'REFERRAL_GROUP_ID' 
;
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "INSPECTOR_PROFILE_REFERRAL_GROUP" MODIFY "REFERRAL_GROUP_ID" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "INSPECTOR_PROFILE_REFERRAL_GROUP" MODIFY "REFERRAL_GROUP_ID" NUMBER(10) NOT NULL';
 end if;
end;
/

declare
   l_nullable user_tab_columns.nullable % type;
begin 
   select nullable into l_nullable 
   from user_tab_columns 
  where table_name = 'INSPECTOR_PROFILE' 
  and column_name = 'PROFILE_TYPE_ID' 
;
   if l_nullable = 'N' then 
        EXECUTE IMMEDIATE 'ALTER TABLE "INSPECTOR_PROFILE" MODIFY "PROFILE_TYPE_ID" NUMBER(10) ';
 else 
        EXECUTE IMMEDIATE 'ALTER TABLE "INSPECTOR_PROFILE" MODIFY "PROFILE_TYPE_ID" NUMBER(10) NOT NULL';
 end if;
end;
/

INSERT INTO "EF_MIGRATION_HISTORY" ("MigrationId", "ProductVersion")
VALUES (N'20251214080549_cmi-021', N'9.0.5')
/

