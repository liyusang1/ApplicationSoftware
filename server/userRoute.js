module.exports = function(app){
    const user = require('../controllers/userController');
    const jwtMiddleware = require('../../../config/jwtMiddleware');

    app.route('/sign-up').post(user.signUp);
    app.route('/sign-in').post(user.signIn);

    app.get('/schedule', jwtMiddleware, user.getSchedule);

    app.get('/class-reference',jwtMiddleware,user.getClassReference);

    app.post('/class-reference',jwtMiddleware,user.postClassReference);

    app.patch('/class-reference/:contentId',jwtMiddleware,user.patchClassReference);

    app.delete('/class-reference/:contentId',jwtMiddleware,user.deleteClassReference);

    app.patch('/class-reference/view/:contentId',user.plusViewCount);

    app.post('/class-room',jwtMiddleware,user.postClassRoom);

    app.get('/class-room',jwtMiddleware,user.getClassRoom);

    app.delete('/class-room/:classRoomId',user.deleteClassRoom);

    app.get('/grade',user.getGrade);

    app.get('/personal-grade',jwtMiddleware,user.getPersonalGrade);

    app.patch('/personal-grade/:idx',user.patchPersonalGrade);
};
