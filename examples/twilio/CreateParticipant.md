<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateParticipant</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Conferences\{ConferenceSid}\Participants.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">ConferenceSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the participant's conference.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateParticipantRequest",
  "required": [
    "From",
    "To"
  ],
  "type": "object",
  "properties": {
    "AmdStatusCallback": {
      "type": "string",
      "description": "The URL that we should call using the `amd_status_callback_method` to notify customer application whether the call was answered by human, machine or fax.",
      "format": "uri"
    },
    "AmdStatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use when calling the `amd_status_callback` URL. Can be: `GET` or `POST` and the default is `POST`.",
      "format": "http-method"
    },
    "Beep": {
      "type": "string",
      "description": "Whether to play a notification beep to the conference when the participant joins. Can be: `true`, `false`, `onEnter`, or `onExit`. The default value is `true`."
    },
    "Byoc": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^BY[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of a BYOC (Bring Your Own Carrier) trunk to route this call with. Note that `byoc` is only meaningful when `to` is a phone number; it will otherwise be ignored. (Beta)"
    },
    "CallReason": {
      "type": "string",
      "description": "The Reason for the outgoing call. Use it to specify the purpose of the call that is presented on the called party's phone. (Branded Calls Beta)"
    },
    "CallSidToCoach": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^CA[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the participant who is being `coached`. The participant being coached is the only participant who can hear the participant who is `coaching`."
    },
    "CallerId": {
      "type": "string",
      "description": "The phone number, Client identifier, or username portion of SIP address that made this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). Client identifiers are formatted `client:name`. If using a phone number, it must be a Twilio number or a Verified [outgoing caller id](https://www.twilio.com/docs/voice/api/outgoing-caller-ids) for your account. If the `to` parameter is a phone number, `callerId` must also be a phone number. If `to` is sip address, this value of `callerId` should be a username portion to be used to populate the From header that is passed to the SIP endpoint."
    },
    "Coaching": {
      "type": "boolean",
      "description": "Whether the participant is coaching another call. Can be: `true` or `false`. If not present, defaults to `false` unless `call_sid_to_coach` is defined. If `true`, `call_sid_to_coach` must be defined."
    },
    "ConferenceRecord": {
      "type": "string",
      "description": "Whether to record the conference the participant is joining. Can be: `true`, `false`, `record-from-start`, and `do-not-record`. The default value is `false`."
    },
    "ConferenceRecordingStatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `conference_recording_status_callback_method` when the conference recording is available.",
      "format": "uri"
    },
    "ConferenceRecordingStatusCallbackEvent": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "The conference recording state changes that generate a call to `conference_recording_status_callback`. Can be: `in-progress`, `completed`, `failed`, and `absent`. Separate multiple values with a space, ex: `'in-progress completed failed'`"
    },
    "ConferenceRecordingStatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `conference_recording_status_callback`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "ConferenceStatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `conference_status_callback_method` when the conference events in `conference_status_callback_event` occur. Only the value set by the first participant to join the conference is used. Subsequent `conference_status_callback` values are ignored.",
      "format": "uri"
    },
    "ConferenceStatusCallbackEvent": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "The conference state changes that should generate a call to `conference_status_callback`. Can be: `start`, `end`, `join`, `leave`, `mute`, `hold`, `modify`, `speaker`, and `announcement`. Separate multiple values with a space. Defaults to `start end`."
    },
    "ConferenceStatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `conference_status_callback`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "ConferenceTrim": {
      "type": "string",
      "description": "Whether to trim leading and trailing silence from your recorded conference audio files. Can be: `trim-silence` or `do-not-trim` and defaults to `trim-silence`."
    },
    "EarlyMedia": {
      "type": "boolean",
      "description": "Whether to allow an agent to hear the state of the outbound call, including ringing or disconnect messages. Can be: `true` or `false` and defaults to `true`."
    },
    "EndConferenceOnExit": {
      "type": "boolean",
      "description": "Whether to end the conference when the participant leaves. Can be: `true` or `false` and defaults to `false`."
    },
    "From": {
      "type": "string",
      "description": "The phone number, Client identifier, or username portion of SIP address that made this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). Client identifiers are formatted `client:name`. If using a phone number, it must be a Twilio number or a Verified [outgoing caller id](https://www.twilio.com/docs/voice/api/outgoing-caller-ids) for your account. If the `to` parameter is a phone number, `from` must also be a phone number. If `to` is sip address, this value of `from` should be a username portion to be used to populate the P-Asserted-Identity header that is passed to the SIP endpoint.",
      "format": "endpoint"
    },
    "JitterBufferSize": {
      "type": "string",
      "description": "Jitter buffer size for the connecting participant. Twilio will use this setting to apply Jitter Buffer before participant's audio is mixed into the conference. Can be: `off`, `small`, `medium`, and `large`. Default to `large`."
    },
    "Label": {
      "type": "string",
      "description": "A label for this participant. If one is supplied, it may subsequently be used to fetch, update or delete the participant."
    },
    "MachineDetection": {
      "type": "string",
      "description": "Whether to detect if a human, answering machine, or fax has picked up the call. Can be: `Enable` or `DetectMessageEnd`. Use `Enable` if you would like us to return `AnsweredBy` as soon as the called party is identified. Use `DetectMessageEnd`, if you would like to leave a message on an answering machine. If `send_digits` is provided, this parameter is ignored. For more information, see [Answering Machine Detection](https://www.twilio.com/docs/voice/answering-machine-detection)."
    },
    "MachineDetectionSilenceTimeout": {
      "type": "integer",
      "description": "The number of milliseconds of initial silence after which an `unknown` AnsweredBy result will be returned. Possible Values: 2000-10000. Default: 5000."
    },
    "MachineDetectionSpeechEndThreshold": {
      "type": "integer",
      "description": "The number of milliseconds of silence after speech activity at which point the speech activity is considered complete. Possible Values: 500-5000. Default: 1200."
    },
    "MachineDetectionSpeechThreshold": {
      "type": "integer",
      "description": "The number of milliseconds that is used as the measuring stick for the length of the speech activity, where durations lower than this value will be interpreted as a human and longer than this value as a machine. Possible Values: 1000-6000. Default: 2400."
    },
    "MachineDetectionTimeout": {
      "type": "integer",
      "description": "The number of seconds that we should attempt to detect an answering machine before timing out and sending a voice request with `AnsweredBy` of `unknown`. The default timeout is 30 seconds."
    },
    "MaxParticipants": {
      "type": "integer",
      "description": "The maximum number of participants in the conference. Can be a positive integer from `2` to `250`. The default value is `250`."
    },
    "Muted": {
      "type": "boolean",
      "description": "Whether the agent is muted in the conference. Can be `true` or `false` and the default is `false`."
    },
    "Record": {
      "type": "boolean",
      "description": "Whether to record the participant and their conferences, including the time between conferences. Can be `true` or `false` and the default is `false`."
    },
    "RecordingChannels": {
      "type": "string",
      "description": "The recording channels for the final recording. Can be: `mono` or `dual` and the default is `mono`."
    },
    "RecordingStatusCallback": {
      "type": "string",
      "description": "The URL that we should call using the `recording_status_callback_method` when the recording status changes.",
      "format": "uri"
    },
    "RecordingStatusCallbackEvent": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "The recording state changes that should generate a call to `recording_status_callback`. Can be: `started`, `in-progress`, `paused`, `resumed`, `stopped`, `completed`, `failed`, and `absent`. Separate multiple values with a space, ex: `'in-progress completed failed'`."
    },
    "RecordingStatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use when we call `recording_status_callback`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "RecordingTrack": {
      "type": "string",
      "description": "The audio track to record for the call. Can be: `inbound`, `outbound` or `both`. The default is `both`. `inbound` records the audio that is received by Twilio. `outbound` records the audio that is sent from Twilio. `both` records the audio that is received and sent by Twilio."
    },
    "Region": {
      "type": "string",
      "description": "The [region](https://support.twilio.com/hc/en-us/articles/223132167-How-global-low-latency-routing-and-region-selection-work-for-conferences-and-Client-calls) where we should mix the recorded audio. Can be:`us1`, `ie1`, `de1`, `sg1`, `br1`, `au1`, or `jp1`."
    },
    "SipAuthPassword": {
      "type": "string",
      "description": "The SIP password for authentication."
    },
    "SipAuthUsername": {
      "type": "string",
      "description": "The SIP username used for authentication."
    },
    "StartConferenceOnEnter": {
      "type": "boolean",
      "description": "Whether to start the conference when the participant joins, if it has not already started. Can be: `true` or `false` and the default is `true`. If `false` and the conference has not started, the participant is muted and hears background music until another participant starts the conference."
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `status_callback_method` to send status information to your application.",
      "format": "uri"
    },
    "StatusCallbackEvent": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "The conference state changes that should generate a call to `status_callback`. Can be: `initiated`, `ringing`, `answered`, and `completed`. Separate multiple values with a space. The default value is `completed`."
    },
    "StatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `status_callback`. Can be: `GET` and `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "TimeLimit": {
      "type": "integer",
      "description": "The maximum duration of the call in seconds. Constraints depend on account and configuration."
    },
    "Timeout": {
      "type": "integer",
      "description": "The number of seconds that we should allow the phone to ring before assuming there is no answer. Can be an integer between `5` and `600`, inclusive. The default value is `60`. We always add a 5-second timeout buffer to outgoing calls, so  value of 10 would result in an actual timeout that was closer to 15 seconds."
    },
    "To": {
      "type": "string",
      "description": "The phone number, SIP address, or Client identifier that received this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). SIP addresses are formatted as `sip:name@company.com`. Client identifiers are formatted `client:name`. [Custom parameters](https://www.twilio.com/docs/voice/api/conference-participant-resource#custom-parameters) may also be specified.",
      "format": "endpoint"
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
      "description": "The URL we should call using the `wait_method` for the music to play while participants are waiting for the conference to start. The default value is the URL of our standard hold music. [Learn more about hold music](https://www.twilio.com/labs/twimlets/holdmusic).",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>