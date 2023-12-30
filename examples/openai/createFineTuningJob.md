<!DOCTYPE html><html><head><title>Creates a job that fine-tunes a specified model from a given dataset.

Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.

[Learn more about fine-tuning](/docs/guides/fine-tuning)
</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates a job that fine-tunes a specified model from a given dataset.

Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.

[Learn more about fine-tuning](/docs/guides/fine-tuning)
</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\fine_tuning\jobs</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "model",
    "training_file"
  ],
  "type": "object",
  "properties": {
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "babbage-002",
            "davinci-002",
            "gpt-3.5-turbo"
          ],
          "type": "string"
        }
      ],
      "description": "The name of the model to fine-tune. You can select one of the\n[supported models](/docs/guides/fine-tuning/what-models-can-be-fine-tuned).\n",
      "example": "gpt-3.5-turbo",
      "x-oaiTypeLabel": "string"
    },
    "training_file": {
      "type": "string",
      "description": "The ID of an uploaded file that contains training data.\n\nSee [upload file](/docs/api-reference/files/upload) for how to upload a file.\n\nYour dataset must be formatted as a JSONL file. Additionally, you must upload your file with the purpose `fine-tune`.\n\nSee the [fine-tuning guide](/docs/guides/fine-tuning) for more details.\n",
      "example": "file-abc123"
    },
    "hyperparameters": {
      "type": "object",
      "properties": {
        "batch_size": {
          "oneOf": [
            {
              "enum": [
                "auto"
              ],
              "type": "string"
            },
            {
              "maximum": 256,
              "minimum": 1,
              "type": "integer"
            }
          ],
          "description": "Number of examples in each batch. A larger batch size means that model parameters\nare updated less frequently, but with lower variance.\n",
          "default": "auto"
        },
        "learning_rate_multiplier": {
          "oneOf": [
            {
              "enum": [
                "auto"
              ],
              "type": "string"
            },
            {
              "minimum": 0,
              "exclusiveMinimum": true,
              "type": "number"
            }
          ],
          "description": "Scaling factor for the learning rate. A smaller learning rate may be useful to avoid\noverfitting.\n",
          "default": "auto"
        },
        "n_epochs": {
          "oneOf": [
            {
              "enum": [
                "auto"
              ],
              "type": "string"
            },
            {
              "maximum": 50,
              "minimum": 1,
              "type": "integer"
            }
          ],
          "description": "The number of epochs to train the model for. An epoch refers to one full cycle\nthrough the training dataset.\n",
          "default": "auto"
        }
      },
      "description": "The hyperparameters used for the fine-tuning job."
    },
    "suffix": {
      "maxLength": 40,
      "minLength": 1,
      "type": "string",
      "description": "A string of up to 18 characters that will be added to your fine-tuned model name.\n\nFor example, a `suffix` of \"custom-model-name\" would produce a model name like `ft:gpt-3.5-turbo:openai:custom-model-name:7p4lURel`.\n",
      "default": null,
      "nullable": true
    },
    "validation_file": {
      "type": "string",
      "description": "The ID of an uploaded file that contains validation data.\n\nIf you provide this file, the data is used to generate validation\nmetrics periodically during fine-tuning. These metrics can be viewed in\nthe fine-tuning results file.\nThe same data should not be present in both train and validation files.\n\nYour dataset must be formatted as a JSONL file. You must upload your file with the purpose `fine-tune`.\n\nSee the [fine-tuning guide](/docs/guides/fine-tuning) for more details.\n",
      "nullable": true,
      "example": "file-abc123"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>