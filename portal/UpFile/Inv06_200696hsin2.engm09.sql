create table engm09 
  (
    em09_kind char(1) not null,
    em09_eng_no char(11) not null,
    em09_eng_no_ext integer,
    em09_cont_code char(5) not null,
    em09_send_cont integer not null,
    em09_begin_work integer not null,
    em09_end_work integer not null,
    em09_appl_settle integer not null,
    em09_settle integer not null,
    em09_acc_settle integer not null,
    em09_mater_settle integer not null,
    em09_check_user char(4) not null,
    em09_user_id char(4),
    em09_upd_datetime datetime year to fraction(3)
  );

create unique index em09_k1 on engm09 (em09_eng_no);




