const {pool} = require('../../../config/database');
const {logger} = require('../../../config/winston');

const jwt = require('jsonwebtoken');
const crypto = require('crypto');
const secret_config = require('../../../config/secret');

const userDao = require('../dao/userDao');

exports.signUp = async function (req, res) {
    const {name, id, major, password, passwordCheck} = req.body;

    if ((!name) || (!id) || (!major) || (!password) || (!passwordCheck)) 
        return res.json({isSuccess: false, code: 301, message: "올바른 값을 입력하세요"});
    
    if (password != passwordCheck) 
        return res.json({isSuccess: false, code: 302, message: "비밀번호 확인이 올바르지 않습니다."});
    
    try {

        const idCheckRows = await userDao.idCheck(id);
        if (idCheckRows[0].CNT > 0) {

            return res.json({isSuccess: false, code: 302, message: "이미 가입된 학번 입니다."});
        }

        const hashedPassword = await crypto
            .createHash('sha512')
            .update(password)
            .digest('hex');
        const insertUserInfoParams = [id, hashedPassword, name, major];

        const insertUserRows = await userDao.insertUserInfo(insertUserInfoParams);

        return res.json({isSuccess: true, code: 200, message: "회원가입 성공"});

    } catch (err) {

        logger.error(`App - SignUp Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.signIn = async function (req, res) {
    const {id, password} = req.body;

    if ((!id) || (!password)) 
        return res.json({isSuccess: false, code: 301, message: "아이디와 비밀번호를 입력해주세요"});
    
    try {
        const [userInfoRows] = await userDao.selectUserInfo(id)
        if (userInfoRows.length < 1) {
            return res.json({isSuccess: false, code: 302, message: "아이디를 확인해주세요."});
        }

        const hashedPassword = await crypto
            .createHash('sha512')
            .update(password)
            .digest('hex');

        if (userInfoRows[0].password !== hashedPassword) {

            return res.json({isSuccess: false, code: 303, message: "비밀번호를 확인해주세요."});
        }

        //JWT
        let token = await jwt.sign({
            id: userInfoRows[0].id,
            identification: userInfoRows[0].identification
        }, secret_config.jwtsecret, { 
            expiresIn: '365d',
            subject: 'userInfo'
        });

        res.json({
            jwt: token,
            isSuccess: true,
            code: 200,
            identification: userInfoRows[0].identification,
            name: userInfoRows[0].name,
            department: userInfoRows[0].major,
            message: "로그인 성공"
        });

    } catch (err) {
        logger.error(`App - SignIn Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.getSchedule = async function (req, res) {

    const {id} = req.verifiedToken;

    try {
        const getScheduleRows = await userDao.getScheduleInfo(id)

        if (getScheduleRows.length >= 0) 
            return res.json(
                {isSuccess: true, code: 200, result: getScheduleRows, count: getScheduleRows.length, message: "조회 성공"}
            );

        }
    catch (err) {
        logger.error(`App - getSchedule Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.getClassReference = async function (req, res) {

    const {id} = req.verifiedToken;

    try {
        const getClassReferenceRows = await userDao.getClassReferenceInfo(id)

        if (getClassReferenceRows.length >= 0) 
            return res.json(
                {isSuccess: true, code: 200, result: getClassReferenceRows, count: getClassReferenceRows.length, message: "조회 성공"}
            );

        }
    catch (err) {
        logger.error(`App - getClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.postClassReference = async function (req, res) {

    const {id} = req.verifiedToken;
    const {
        classId,
        contentName,
        content,
        fontSize,
        isBold,
        isItalic,
        isUnderline,
        fontType,
        fileName,
        file
    } = req.body;

    try {
        const postClassReferenceParams = [
            classId,
            id,
            contentName,
            content,
            fontSize,
            isBold,
            isItalic,
            isUnderline,
            fontType,
            fileName,
            file
        ];

        const postClassReferenceRows = await userDao.postClassReferenceInfo(
            postClassReferenceParams
        )

        return res.json({isSuccess: true, code: 200, message: "글 작성 성공"});

    } catch (err) {
        logger.error(`App - postClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.patchClassReference = async function (req, res) {

    const {id} = req.verifiedToken;
    const {contentId} = req.params;
    const {
        contentName,
        content,
        fontSize,
        isBold,
        isItalic,
        isUnderline,
        fontType,
        fileName,
        file
    } = req.body;

    try {
        const patchClassReferenceParams = [
            contentName,
            content,
            fontSize,
            isBold,
            isItalic,
            isUnderline,
            fontType,
            fileName,
            file,
            contentId
        ];

        const patchClassReferenceRows = await userDao.patchClassReferenceInfo(
            patchClassReferenceParams
        )

        return res.json({isSuccess: true, code: 200, message: "글 수정 성공"});

    } catch (err) {
        logger.error(`App - patchClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.deleteClassReference = async function (req, res) {

    const {id} = req.verifiedToken;
    const {contentId} = req.params;

    try {

        const deleteClassReferenceRows = await userDao.deleteClassReferenceInfo(
            contentId
        )

        return res.json({isSuccess: true, code: 200, message: "글 삭제 성공"});

    } catch (err) {
        logger.error(`App - deleteClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.plusViewCount = async function (req, res) {

    const {contentId} = req.params;

    try {

        const plusViewCountRows = await userDao.plusViewCountInfo(contentId)

        return res.json({isSuccess: true, code: 200, message: "조회수 증가 성공"});

    } catch (err) {
        logger.error(`App - deleteClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.postClassRoom = async function (req, res) {

    const {id} = req.verifiedToken;
    const {
        classId,
        classWeek,
        classChapter,
        classDistinct,
        classTime,
        classContext,
        classUrl
    } = req.body;
    const postClassRoomParams = [
        classId,
        id,
        classWeek,
        classChapter,
        classDistinct,
        classTime,
        classContext,
        classUrl
    ]

    try {

        const postClassRoomRows = await userDao.postClassRoom(postClassRoomParams)

        return res.json({isSuccess: true, code: 200, message: "강의 등록 성공"});

    } catch (err) {
        logger.error(`App - deleteClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.getClassRoom = async function (req, res) {

    const {id} = req.verifiedToken;

    try {

        const getClassRoomRows = await userDao.getClassRoom(id)

        return res.json(
            {isSuccess: true, code: 200, result: getClassRoomRows, count: getClassRoomRows.length, message: "강의 목록 조회 성공"}
        );

    } catch (err) {
        logger.error(`App - deleteClassReference Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.deleteClassRoom = async function (req, res) {

    const {classRoomId} = req.params;

    try {

        const deleteClassRoomRows = await userDao.deleteClassRoom(classRoomId)

        return res.json({isSuccess: true, code: 200, message: "삭제 완료"});

    } catch (err) {
        logger.error(`App - deleteClassRoom Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.getGrade = async function (req, res) {

    try {

        const getGradeRows = await userDao.getGrade()

        return res.json(
            {isSuccess: true, code: 200, result: getGradeRows, count: getGradeRows.length, message: "조회 완료"}
        );

    } catch (err) {
        logger.error(`App - getGrade Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.getPersonalGrade = async function (req, res) {

    const {id} = req.verifiedToken;

    try {

        const getPersonalGradeRows = await userDao.getPersonalGrade(id)

        return res.json(
            {isSuccess: true, code: 200, result: getPersonalGradeRows, count: getPersonalGradeRows.length, message: "조회 완료"}
        );

    } catch (err) {
        logger.error(`App - getPersonalGrade Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};

exports.patchPersonalGrade = async function (req, res) {

    const {idx} = req.params;
    const {grade} = req.body;

    try {

        const patchPersonalGradeParams = [grade, idx];
        const patchPersonalGradeRows = await userDao.patchPersonalGrade(
            patchPersonalGradeParams
        )

        return res.json({isSuccess: true, code: 200, message: "수정 완료"});

    } catch (err) {
        logger.error(`App - patchPersonalGrade Query error\n: ${err.message}`);
        return res
            .status(500)
            .send(`Error: ${err.message}`);
    }
};