create table appm01 
  (
    am01_total_no integer not null,
    am01_house_no integer not null,
    am01_name char(40) not null,
    am01_id_no char(10) not null,
    am01_canton char(1),
    am01_street smallint,
    am01_section smallint,
    am01_lane smallint,
    am01_alley smallint,
    am01_number char(4),
    am01_dash char(2),
    am01_number2 smallint,
    am01_sub_no smallint,
    am01_floor char(2),
    am01_room char(4),
    am01_alt_addr1 char(33) not null,
    am01_alt_addr2 char(30) not null,
    am01_zone1 char(3) not null,
    am01_telno1 char(10) not null,
    am01_ext1 char(5),
    am01_remark1 char(20),
    am01_zone2 char(3) not null,
    am01_telno2 char(10) not null,
    am01_remark2 char(20),
    am01_telno3 char(12),
    am01_remark3 char(20),
    am01_company_no char(10) not null,
    am01_cno_start integer,
    am01_cno_stop integer,
    am01_last_appl char(1),
    am01_usage char(1),
    am01_post_type char(2),
    am01_post_name char(40),
    am01_post_no char(20),
    am01_post_start integer,
    am01_post_stop integer,
    am01_post_stop_r char(1),
    am01_emp_mark char(1),
    am01_emp_date integer,
    am01_vol_no char(3),
    am01_mtr_mark char(1),
    am01_mtr_date integer,
    am01_mtr_class char(1),
    am01_mtr_dpzt_mk char(1),
    am01_gas_dpzt_mk char(1),
    am01_user_id char(4),
    am01_upd_datetime datetime year to fraction(3),
    am01_ald_mark char(1),
    am01_esv_mark char(1),
    am01_esv_yorn char(1)
  );

create unique index appm01_k1 on appm01 (am01_total_no);
create index appm01_k8 on appm01 (am01_name desc);
create index appm01_k10 on appm01 (am01_house_no desc);
create index appm01_k11 on appm01 (am01_vol_no);
create index appm01_k4 on appm01 (am01_alt_addr2,am01_total_no);
create index appm01_k9 on appm01 (am01_alt_addr2 desc,am01_total_no desc);
create index appm01_k2 on appm01 (am01_house_no);
create index appm01_k3 on appm01 (am01_name);
create index appm01_k5 on appm01 (am01_zone1,am01_telno1);
create index appm01_k6 on appm01 (am01_zone2,am01_telno2);
create index appm01_k7 on appm01 (am01_id_no);
create index am01_k13 on appm01 (am01_post_type);
create index am01_k14 on appm01 (am01_post_start);
create unique index am01_kk1 on appm01 (am01_total_no desc);
create index appm01_k15 on appm01 (am01_telno3);
create index appm01_k16 on appm01 (am01_post_name);