-- Information Table Create SQL
CREATE TABLE Information
(
    `Id`              INT UNSIGNED    NOT NULL    COMMENT '학번',
    `password`        VARCHAR(100)    NOT NULL    COMMENT '비밀번호',
    `name`            VARCHAR(10)     NOT NULL    COMMENT '이름',
    `major`           VARCHAR(20)     NOT NULL    COMMENT '전공',
    `identification`  TINYINT         NOT NULL    DEFAULT 0 COMMENT '0:학생 1:교수',
    `createdAt`       TIMESTAMP       NOT NULL    DEFAULT current_timestamp,
    CONSTRAINT  PRIMARY KEY (Id)
);

ALTER TABLE Information COMMENT '학생 및 교수 정보';

-- Information Table Create SQL
CREATE TABLE Schedule
(
    `Id`         INT UNSIGNED    NOT NULL    COMMENT '학생학번',
    `classId`    VARCHAR(20)     NOT NULL,
    `createdAt`  TIMESTAMP       NOT NULL    DEFAULT current_timestamp,
    CONSTRAINT  PRIMARY KEY (Id)
);

ALTER TABLE Schedule COMMENT '시간표';

-- Information Table Create SQL
CREATE TABLE Class
(
    `classId`    INT UNSIGNED    NOT NULL    AUTO_INCREMENT,
    `className`  VARCHAR(20)     NOT NULL,
    `time1`      TINYINT         NOT NULL,
    `time2`      TINYINT         NOT NULL,
    `day`        TINYINT         NOT NULL,
    `Id`         TINYINT         NOT NULL,
    `createdAt`  TIMESTAMP       NOT NULL    DEFAULT current_timestamp,
    CONSTRAINT  PRIMARY KEY (classId)
);

ALTER TABLE Class COMMENT '과목';


-- Information Table Create SQL
CREATE TABLE ClassReference
(
    `classId`      INT UNSIGNED    NOT NULL,
    `Id`           INT UNSIGNED    NOT NULL    COMMENT '교수 아이디',
    `contentName`  VARCHAR(45)     NOT NULL,
    `content`      TEXT            NOT NULL,
    `viewCount`    INT UNSIGNED    NOT NULL,
    `file`         BLOB            NOT NULL,
    `createdAt`    TIMESTAMP       NOT NULL    DEFAULT current_timestamp,
    CONSTRAINT  PRIMARY KEY (classId)
);

ALTER TABLE ClassReference COMMENT '강의 자료실';


-- Information Table Create SQL
CREATE TABLE ClassRoom
(
    `classId`        INT UNSIGNED    NOT NULL,
    `Id`             INT UNSIGNED    NOT NULL    COMMENT '교수 아이디',
    `classDeadline`  VARCHAR(45)     NOT NULL    COMMENT '학습기간',
    `classContent`   VARCHAR(45)     NOT NULL    COMMENT '학습목차',
    `classUrl`       TEXT            NOT NULL    COMMENT '학습하기 링크',
    `classTime`      INT UNSIGNED    NOT NULL    COMMENT '학습 인정 시간',
    `createdAt`      TIMESTAMP       NOT NULL    DEFAULT current_timestamp,
    CONSTRAINT  PRIMARY KEY (classId)
);

ALTER TABLE ClassRoom COMMENT '강의 보기';

SELECT COUNT(1) as CNT FROM Information where id = ?;

INSERT INTO Information (id,password,name,major) VALUES (?,?,?,?);

SELECT id,password,identification FROM Information WHERE id = ?;

SELECT className,time1,day1,time2,day2,classRoom,
(SELECT name from Information where Information.Id = Class.Id) as professorName
FROM Schedule
INNER JOIN Information ON Schedule.Id = Information.Id
INNER JOIN Class ON Schedule.classId = Class.classId
where Information.Id = ?;

SELECT contentId,contentName,
(SELECT name FROM Information WHERE Information.Id = ClassReference.Id)as ProfessorName,
(SELECT className from Class where ClassReference.classId = Class.classId)as className,
       date_format(ClassReference.createdAt, '%Y-%m-%d') as createdAt,viewCount,content,fontType,fontSize,isBold,isItalic,isUnderline
FROM ClassReference
INNER JOIN Schedule ON Schedule.classId = ClassReference.classId
WHERE Schedule.Id = ? ;

SELECT COUNT(1) as CNT FROM Information where id = ?;

INSERT INTO ClassReference (contentName, Id, classId, content, fontSize, isBold, isItalic, isUnderline, fontType)
VALUES (?,?,?,?,?,?,?,?,? );

UPDATE ClassReference SET contentName = ?, content = ?,fontSize =? ,isBold= ? , isItalic= ? ,isUnderline = ?,fontType =?
WHERE contentId = ?

DELETE FROM ClassReference WHERE contentId = ?

UPDATE ClassReference SET viewCount = viewCount + 1 WHERE contentId = ?;

INSERT INTO ClassRoom (classId,Id,classWeek, classChapter,classDistinct,classTime,classContext,classUrl)
VALUES (?,?,?,?,?,?,?,?);


SELECT (SELECT className from Class where ClassRoom.classId = Class.classId)as className,
       classWeek,classChapter,classDistinct,classContext,classTime,classUrl,classRoomId

FROM ClassRoom
INNER JOIN Schedule ON Schedule.classId = ClassRoom.classId
WHERE Schedule.Id = ? ;

INSERT INTO ClassReference (classId,Id,contentName,content,fontSize,isBold,isItalic,isUnderline,fontType,fileName,file)
VALUES (?,?,?,?,?,?,?,?,?,?,?);


DELETE FROM ClassRoom WHERE classRoomId = ?

SELECT idx,className,name,Schedule.grade from Information
INNER JOIN Schedule
INNER JOIN Class On Schedule.classId = Class.classId

WHERE Information.Id = Schedule.Id And identification = 0;

SELECT infoNumber,className,department,category,grade FROM Schedule
INNER JOIN Class ON Class.classId = Schedule.classId
WHERE Schedule.Id = ?;


UPDATE Schedule SET grade = ? WHERE idx = ?;