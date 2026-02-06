create table appm14 
  (
    am14_charge_yymm smallint not null,
    am14_sheet_no integer,
    am14_house_no integer not null,
    am14_company_no char(10),
    am14_post_type char(2),
    am14_post_no char(20),
    am14_emp_mark char(1),
    am14_vol_no char(3),
    am14_clip_date integer,
    am14_pay_date integer,
    am14_next_clip_dt integer,
    am14_next_pay_dt integer,
    am14_limit_date integer,
    am14_mtr_class char(1),
    am14_mtr_dpzt_mk char(1),
    am14_gas_dpzt_mk char(1),
    am14_usage char(1),
    am14_mtr_point integer,
    am14_use_point integer,
    am14_clip_code char(2),
    am14_adj_mark char(1),
    am14_adj_amt integer,
    am14_gas_point integer,
    am14_gas_price smallint,
    am14_gas_amt integer,
    am14_mtr_rent_amt integer,
    am14_tax_amt integer,
    am14_total_amt integer,
    am14_emp_disc integer,
    am14_note_point integer,
    am14_note_mark char(1),
    am14_clip_user char(4),
    am14_modify_user char(4),
    am14_modify_date integer,
    am14_recv_date integer,
    am14_post_type_c char(2),
    am14_post_no_c char(20),
    am14_pay_date_c integer,
    am14_mtr_code char(1),
    am14_mtr_date integer,
    am14_clip_update integer,
    am14_base_fee integer,
    am14_switch1_amt integer,
    am14_switch2_amt integer,
    am14_pp1_amt integer,
    am14_pp2_amt integer,
    am14_mtr_m char(1),
    am14_road_fee integer,
    am14_oth_amt1 integer,
    am14_oth_amt2 integer,
    am14_user_id char(4),
    am14_upd_datetime datetime year to fraction(3)
  );

create unique index "informix".appm14x_k1 on appm14 (am14_house_no,am14_charge_yymm);
create unique index "informix".appm14x_k2 on appm14 (am14_pay_date,am14_house_no);
create index "informix".appm14x_k3 on appm14 (am14_recv_date);
create unique index "informix".appm14x_k4 on appm14 (am14_house_no desc,am14_charge_yymm);
create index "informix".appm14x_k6 on appm14 (am14_post_type,am14_post_no);
create index "informix".appm14x_k7 on appm14 (am14_post_type_c,am14_post_no_c);
create index "informix".appm14x_k8 on appm14 (am14_pay_date_c desc);