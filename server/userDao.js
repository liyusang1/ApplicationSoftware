const {pool} = require("../../../config/database");

//id check
async function idCheck(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const idCheckQuery = `
  SELECT COUNT(1) as CNT FROM Information where id = ?;
                `;
    const [idCheckRows] = await connection.query(idCheckQuery, id);
    connection.release();

    return idCheckRows;
}

async function insertUserInfo(insertUserInfoParams) {
    const connection = await pool.getConnection(async (conn) => conn);
    const insertUserInfoQuery = `
  INSERT INTO Information (id,password,name,major) VALUES (?,?,?,?);
                `;
    const [insertUserInfoRows] = await connection.query(
        insertUserInfoQuery,
        insertUserInfoParams
    );
    connection.release();

    return insertUserInfoRows;
}

async function selectUserInfo(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const selectUserInfoQuery = `
  SELECT id,password,identification,major,name FROM Information WHERE id = ?
                `;
    const [selectUserInfoRows] = await connection.query(selectUserInfoQuery, id);
    connection.release();

    return [selectUserInfoRows];
}

async function getScheduleInfo(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const getScheduleInfoQuery = `
  SELECT className,time1,day1,time2,day2,classRoom,
  (SELECT name from Information where Information.Id = Class.Id) AS professorName
  FROM Schedule
  INNER JOIN Information ON Schedule.Id = Information.Id
  INNER JOIN Class ON Schedule.classId = Class.classId
  WHERE Information.Id = ?;
                `;
    const [getScheduleInfoRows] = await connection.query(getScheduleInfoQuery, id);
    connection.release();

    return getScheduleInfoRows;
}

async function getClassReferenceInfo(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const getClassReferenceInfoQuery = `
  SELECT contentId,contentName,
  (SELECT name FROM Information WHERE Information.Id = ClassReference.Id)as ProfessorName,
  (SELECT className from Class where ClassReference.classId = Class.classId)as className,
       date_format(ClassReference.createdAt, '%Y-%m-%d') as createdAt,viewCount,content,fontType,fontSize,isBold,isItalic,isUnderline,
       file,fileName
  FROM ClassReference
  INNER JOIN Schedule ON Schedule.classId = ClassReference.classId
  WHERE Schedule.Id = ? ;
                `;
    const [getClassReferenceInfoRows] = await connection.query(
        getClassReferenceInfoQuery,
        id
    );
    connection.release();

    return getClassReferenceInfoRows;
}

async function postClassReferenceInfo(postClassReferenceParams) {
    const connection = await pool.getConnection(async (conn) => conn);
    const postClassReferenceInfoQuery = `
  
  INSERT INTO ClassReference (classId,Id,contentName,content,fontSize,isBold,isItalic,isUnderline,fontType,fileName,file)
  VALUES (?,?,?,?,?,?,?,?,?,?,?);

                `;
    const [postClassReferenceInfoRows] = await connection.query(
        postClassReferenceInfoQuery,
        postClassReferenceParams
    );
    connection.release();

    return postClassReferenceInfoRows;
}

async function patchClassReferenceInfo(patchClassReferenceParams) {
    const connection = await pool.getConnection(async (conn) => conn);
    const patchClassReferenceInfoQuery = `
  
  UPDATE ClassReference SET contentName = ?, content = ?,fontSize =? ,isBold= ? , isItalic= ? ,isUnderline = ?,fontType =?,
  fileName = ?,file =?
  WHERE contentId = ?

                `;
    const [patchClassReferenceInfoRows] = await connection.query(
        patchClassReferenceInfoQuery,
        patchClassReferenceParams
    );
    connection.release();

    return patchClassReferenceInfoRows;
}

async function deleteClassReferenceInfo(contentId) {
    const connection = await pool.getConnection(async (conn) => conn);
    const deleteClassReferenceInfoQuery = `
  
  DELETE FROM ClassReference WHERE contentId = ?

                `;
    const [deleteClassReferenceInfoRows] = await connection.query(
        deleteClassReferenceInfoQuery,
        contentId
    );
    connection.release();

    return deleteClassReferenceInfoRows;
}

async function plusViewCountInfo(contentId) {
    const connection = await pool.getConnection(async (conn) => conn);
    const plusViewCountQuery = `
  
  UPDATE ClassReference SET viewCount = viewCount + 1 WHERE contentId = ?;

                `;
    const [plusViewCountRows] = await connection.query(
        plusViewCountQuery,
        contentId
    );
    connection.release();

    return plusViewCountRows;
}

async function postClassRoom(postClassRoomParams) {
    const connection = await pool.getConnection(async (conn) => conn);
    const postClassRoomQuery = `
  
  INSERT INTO ClassRoom (classId,Id,classWeek, classChapter,classDistinct,classTime,classContext,classUrl)
  VALUES (?,?,?,?,?,?,?,?);

                `;
    const [plusViewCountRows] = await connection.query(
        postClassRoomQuery,
        postClassRoomParams
    );
    connection.release();

    return plusViewCountRows;
}

async function getClassRoom(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const getClassRoomQuery = `
  
  SELECT (SELECT className from Class where ClassRoom.classId = Class.classId)as className,
       classWeek,classChapter,classDistinct,classContext,classTime,classUrl,classRoomId

  FROM ClassRoom
  INNER JOIN Schedule ON Schedule.classId = ClassRoom.classId
  WHERE Schedule.Id = ? ;

                `;
    const [getClassRoomRows] = await connection.query(getClassRoomQuery, id);
    connection.release();

    return getClassRoomRows;
}

async function deleteClassRoom(classRoomId) {
    const connection = await pool.getConnection(async (conn) => conn);
    const deleteClassRoomQuery = `

  DELETE FROM ClassRoom WHERE classRoomId = ?
  
                `;
    const [deleteClassRoomRows] = await connection.query(
        deleteClassRoomQuery,
        classRoomId
    );
    connection.release();

    return deleteClassRoomRows;
}

async function getGrade() {
    const connection = await pool.getConnection(async (conn) => conn);
    const getGradeQuery = `

  SELECT idx,className,name,Schedule.grade from Information
  INNER join Schedule
  INNER JOIN Class On Schedule.classId = Class.classId

  WHERE Information.Id = Schedule.Id And identification = 0;
  
                `;
    const [getGradeRows] = await connection.query(getGradeQuery,);
    connection.release();

    return getGradeRows;
}

async function getPersonalGrade(id) {
    const connection = await pool.getConnection(async (conn) => conn);
    const getPersonalGradeQuery = `

  SELECT infoNumber,className,department,category,grade FROM Schedule
  INNER JOIN Class ON Class.classId = Schedule.classId
  WHERE Schedule.Id = ?
                `;
    const [getGradeRows] = await connection.query(getPersonalGradeQuery, id);
    connection.release();

    return getGradeRows;
}

async function patchPersonalGrade(patchPersonalGradeParams) {
    const connection = await pool.getConnection(async (conn) => conn);
    const patchPersonalGradeQuery = `

  UPDATE Schedule SET grade = ? WHERE idx = ?;
  
                `;
    const [patchPersonalGradeRows] = await connection.query(
        patchPersonalGradeQuery,
        patchPersonalGradeParams
    );
    connection.release();

    return patchPersonalGradeRows;
}

module.exports = {
    idCheck,
    insertUserInfo,
    selectUserInfo,
    getScheduleInfo,
    getClassReferenceInfo,
    postClassReferenceInfo,
    patchClassReferenceInfo,
    deleteClassReferenceInfo,
    plusViewCountInfo,
    postClassRoom,
    getClassRoom,
    deleteClassRoom,
    getGrade,
    getPersonalGrade,
    patchPersonalGrade
};
