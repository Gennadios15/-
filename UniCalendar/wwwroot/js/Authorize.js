const CLIENT_ID = '830898581755-jcl182s380a54u3g2ampim9dgmnp0bkr.apps.googleusercontent.com';
const API_KEY = 'AIzaSyAEJXw1Y26rqxwvxkDQvxNYOvWFn22FhEY';
const DISCOVERY_DOC = 'https://www.googleapis.com/discovery/v1/apis/calendar/v3/rest';
const SCOPES = 'https://www.googleapis.com/auth/calendar.readonly';

let tokenClient;
let gapiInited = false;
let gisInited = false;

function checkSignInState() {
    const accessToken = localStorage.getItem('accessToken');
    console.log('Access Token:', accessToken);
    if (accessToken) {
        document.getElementById('authorize_button').style.display = 'none';
        document.getElementById('signup_button').style.display = 'none';
        document.getElementById('signout_button').style.display = 'inline';
    } else {
        document.getElementById('authorize_button').style.display = 'inline';
        document.getElementById('signup_button').style.display = 'inline';
        document.getElementById('signout_button').style.display = 'none';
    }
}

function gapiLoaded() {
    if (!gapiInited) {
        gapi.load('client', initializeGapiClient);
    }
}

async function initializeGapiClient() {
    if (!gapiInited) {
        await gapi.client.init({
            apiKey: API_KEY,
            discoveryDocs: [DISCOVERY_DOC],
        });
        gapiInited = true;
        maybeEnableButtons();
    }
}

function gisLoaded() {
    if (!gisInited) {
        tokenClient = google.accounts.oauth2.initTokenClient({
            client_id: CLIENT_ID,
            scope: SCOPES,
            callback: '', // defined later
        });
        gisInited = true;
        maybeEnableButtons();
    }
}

function maybeEnableButtons() {
    if (gapiInited && gisInited) {
        checkSignInState();
        document.getElementById('authorize_button').style.display = 'inline';
    }
}

function handleAuthClick() {
    tokenClient.callback = async (resp) => {
        if (resp.error !== undefined) {
            throw (resp);
        }
        localStorage.setItem('accessToken', resp.access_token);
        checkSignInState();
        await listUpcomingEvents();
    };

    if (gapi.client.getToken() === null) {
        tokenClient.requestAccessToken({ prompt: 'consent' });
    } else {
        tokenClient.requestAccessToken({ prompt: '' });
    }
    document.getElementById("MyLessons").classList.toggle("showMyMenu");
    document.getElementById("MyProgram").classList.toggle("showMyMenu");
}

function handleSignoutClick() {
    const token = localStorage.getItem('accessToken');
    if (token !== null) {
        google.accounts.oauth2.revoke(token);
        localStorage.removeItem('accessToken');
        checkSignInState();
    }
}

function listUpcomingEvents() {
    if (sessionStorage.getItem('accessToken') !== null) {
        // Code to list upcoming events
        // Add your implementation here
    } else {
        console.log('Access Token is null. Cannot list upcoming events.');
    }
}

window.onload = function () {
    checkSignInState();
};
