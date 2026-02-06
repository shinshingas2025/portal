create table appm03 
  (
    am03_rcp_no char(9) not null,
    am03_rcp_date integer,
    am03_rcp_kind char(1) not null,
    am03_rcp_cnt smallint,
    am03_discount smallint,
    am03_rcp_amt integer,
    am03_install smallint,
    am03_install_now smallint,
    am03_rcp_name char(40),
    am03_recv_user char(4),
    am03_mark char(1),
    am03_de_user char(4),
    am03_user_id char(4),
    am03_upd_datetime datetime year to fraction(3)
  );

create unique index appm03_k1 on appm03 (am03_rcp_no,am03_rcp_kind);
create index am03_k2 on appm03 (am03_rcp_name);