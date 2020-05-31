CREATE SCHEMA IF NOT EXISTS covid19_hackathon_schema;
SET search_path to covid19_hackathon_schema;


CREATE TABLE IF NOT EXISTS covid19_hackathon_schema.number_utility
(
    number INTEGER NOT NULL
) 
;

CREATE TABLE IF NOT EXISTS covid19_hackathon_schema.date_dimension
(
	datedimensionid SMALLINT NOT NULL UNIQUE,
	full_date DATE NOT NULL,
	iso_format_date CHAR(10) NOT NULL,
	uk_format_date CHAR(10) NOT NULL,
	us_format_date CHAR(10)  NOT NULL,
	year_number SMALLINT NOT NULL,
	year_week_number SMALLINT NOT NULL,
	year_day_number SMALLINT  NOT NULL,
	fiscal_year_number SMALLINT NOT NULL,
	fiscal_qtr_number SMALLINT  NOT NULL,
	qtr_number SMALLINT NOT NULL,
	month_number SMALLINT  NOT NULL,
	month_name_en CHAR(9)  NOT NULL,
	month_name_fr CHAR(9) DEFAULT NULL,
	month_day_number SMALLINT  NOT NULL,
	week_day_number SMALLINT  NOT NULL,
	day_name_en CHAR(9) NOT NULL,
	day_name_fr CHAR(9)  DEFAULT NULL,
	day_is_weekday VARCHAR(1)  NOT NULL,
	day_is_last_of_month CHAR(1) NOT NULL,
	primary key (datedimensionid)
)
;

COMMENT ON TABLE covid19_hackathon_schema.date_dimension IS '{"primary_keys":["datedimensionid"]}';

CREATE TABLE IF NOT EXISTS covid19_hackathon_schema.covid_cases
(
	case_id INT NOT NULL UNIQUE,
	case_recorded_date DATE NOT NULL,
	lat DECIMAL NOT NULL,
    long DECIMAL NOT NULL,
    Patient_Age smallint,
    Patient_Gender smallint,
    Case_Outcome VARCHAR(12) NOT NULL,
    Location_Type VARCHAR(12) NOT NULL,
    Placename VARCHAR(128) NOT NULL,
	primary key (case_id)
)
;


  --populate the numbers
    INSERT INTO number_utility VALUES (1), (2), (3), (4), (5), (6), (7), (8);
    INSERT INTO number_utility SELECT number + 8 FROM number_utility;
    INSERT INTO number_utility SELECT number + 16 FROM number_utility;
    INSERT INTO number_utility SELECT number + 32 FROM number_utility;
    INSERT INTO number_utility SELECT number + 64 FROM number_utility;
    INSERT INTO number_utility SELECT number + 128 FROM number_utility;
    INSERT INTO number_utility SELECT number + 256 FROM number_utility;
    INSERT INTO number_utility SELECT number + 512 FROM number_utility;
	INSERT INTO number_utility SELECT number + 1024 FROM number_utility;
	INSERT INTO number_utility SELECT number + 2048 FROM number_utility;
	INSERT INTO number_utility SELECT number + 4096 FROM number_utility;
	INSERT INTO number_utility SELECT number + 8192 FROM number_utility;
	INSERT INTO number_utility SELECT number + 16384 FROM number_utility;
	INSERT INTO number_utility SELECT number + 32768 FROM number_utility;
	INSERT INTO number_utility SELECT number + 65536 FROM number_utility;
    INSERT INTO number_utility VALUES (0);


	-- INSERT THE DATES
	
   -- populate the dates
    INSERT INTO date_dimension
    SELECT
    cast(seq + 1 AS INTEGER) AS datedimensionid,

    -- DATE
    datum AS full_date,
	TO_CHAR(datum, 'YYYY-MM-DD') :: CHAR(10) AS iso_format_date,
    TO_CHAR(datum, 'DD/MM/YYYY') :: CHAR(10) AS uk_format_date,
    TO_CHAR(datum, 'MM/DD/YYYY') :: CHAR(10) AS us_format_date,

    -- YEAR
    cast(extract(YEAR FROM datum) AS SMALLINT) AS year_number,
    cast(extract(WEEK FROM datum) AS SMALLINT) AS year_week_number,
    cast(extract(DOY FROM datum) AS SMALLINT) AS year_day_number,
    cast(to_char(datum + INTERVAL '6' MONTH, 'yyyy') AS SMALLINT) AS fiscal_year_number,

    -- QUARTER
    cast(to_char(datum + INTERVAL '6' MONTH, 'Q') AS SMALLINT) AS fiscal_qtr_number,
	cast(to_char(datum, 'Q') AS SMALLINT) AS qtr_number,
    
    -- MONTH
    cast(extract(MONTH FROM datum) AS SMALLINT) AS month_number,
    to_char(datum, 'Month') AS month_name_en,
	'' AS month_name_fr,
    cast(extract(DAY FROM datum) AS SMALLINT) AS month_day_number,

    -- WEEK
    cast(to_char(datum, 'D') AS SMALLINT) AS week_day_number,

    -- DAY
    to_char(datum, 'Day') AS day_name_en,
	'' AS day_name_fr,
    CASE WHEN to_char(datum, 'D') IN ('1', '7')
    THEN 0
    ELSE 1 END AS day_is_weekday,
    CASE WHEN
    extract(DAY FROM (datum + (1 - extract(DAY FROM datum)) :: INTEGER +
    INTERVAL '1' MONTH) :: DATE -
    INTERVAL '1' DAY) = extract(DAY FROM datum)
    THEN 1
    ELSE 0 END AS day_is_last_of_month
    FROM
    -- Generate days for ~60 years starting from 1995.
    (
    SELECT
    '1995-01-01' :: DATE + number AS datum,
    number AS seq
    FROM number_utility
    WHERE number < 60 * 365
    ) DQ
    ORDER BY 1;