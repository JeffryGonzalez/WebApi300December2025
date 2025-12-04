# Employees

In our company, we use the following schema to define Employees across the company. This can be extended, but... blah

If you don't know how to read this, see JSon Schema .org.

```json
{
  "required": ["name"],
  "type": "object",
  "properties": {
    "name": {
      "maxLength": 50,
      "minLength": 3,
      "type": "string"
    },
    "phone": {
      "type": "string"
    }
  }
}
```
