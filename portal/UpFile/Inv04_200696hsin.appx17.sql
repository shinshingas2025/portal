create table appm17 
  (
    am17_house_no integer not null,
    am17_input_dt integer,
    am17_reason_cd char(1),
    am17_amount integer,
    am17_yymm_start smallint,
    am17_yymm_stop smallint,
    am17_print_date integer,
    am17_print_time integer,
    am17_rcp_user char(4),
    am17_reason char(20),
    am17_rcp_no char(6),
    am17_recv_date integer,
    am17_recv_time integer,
    am17_de_user char(4),
    am17_user_id char(4),
    am17_upd_datetime datetime year to fraction(3)
  );

create unique index appm17x_k1 on appm17 (am17_house_no,am17_input_dt);