<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">UpdateParticipant</h1><p  class="requestDescription">Update the properties of the participant</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Conferences\{ConferenceSid}\Participants\{CallSid}.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resources to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">ConferenceSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the conference with the participant to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">CallSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to update. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "UpdateParticipantRequest",
  "type": "object",
  "properties": {
    "AnnounceMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `announce_url`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "AnnounceUrl": {
      "type": "string",
      "description": "The URL we call using the `announce_method` for an announcement to the participant. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs.",
      "format": "uri"
    },
    "BeepOnExit": {
      "type": "boolean",
      "description": "Whether to play a notification beep to the conference when the participant exits. Can be: `true` or `false`."
    },
    "CallSidToCoach": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^CA[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the participant who is being `coached`. The participant being coached is the only participant who can hear the participant who is `coaching`."
    },
    "Coaching": {
      "type": "boolean",
      "description": "Whether the participant is coaching another call. Can be: `true` or `false`. If not present, defaults to `false` unless `call_sid_to_coach` is defined. If `true`, `call_sid_to_coach` must be defined."
    },
    "EndConferenceOnExit": {
      "type": "boolean",
      "description": "Whether to end the conference when the participant leaves. Can be: `true` or `false` and defaults to `false`."
    },
    "Hold": {
      "type": "boolean",
      "description": "Whether the participant should be on hold. Can be: `true` or `false`. `true` puts the participant on hold, and `false` lets them rejoin the conference."
    },
    "HoldMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `hold_url`. Can be: `GET` or `POST` and the default is `GET`.",
      "format": "http-method"
    },
    "HoldUrl": {
      "type": "string",
      "description": "The URL we call using the `hold_method` for music that plays when the participant is on hold. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs.",
      "format": "uri"
    },
    "Muted": {
      "type": "boolean",
      "description": "Whether the participant should be muted. Can be `true` or `false`. `true` will mute the participant, and `false` will un-mute them. Anything value other than `true` or `false` is interpreted as `false`."
    },
    "WaitMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `wait_url`. Can be `GET` or `POST` and the default is `POST`. When using a static audio file, this should be `GET` so that we can cache the file.",
      "format": "http-method"
    },
    "WaitUrl": {
      "type": "string",
      "description": "The URL we call using the `wait_method` for the music to play while participants are waiting for the conference to start. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs. The default value is the URL of our standard hold music. [Learn more about hold music](https://www.twilio.com/labs/twimlets/holdmusic).",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>