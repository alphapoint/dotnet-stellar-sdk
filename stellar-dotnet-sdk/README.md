# Horizon Protocol Changelog

Any changes to the Horizon Public API should be included in this doc. We will keep this in sync or Stellar's version
located at https://github.com/stellar/go/tree/master/protocols/horizon/README.md



## SDK support

We started tracking SDK support at version 0.12.3. Support for 0.12.3 means that SDK can correctly:

* Send requests using all available query params / POST params / headers,
* Parse all fields in responses structs and headers.

For each new version we will only track changes from the previous version.

## Changes

### 0.15.0

#### Changes

* Assets stats are disabled by default. This can be changed using an environment variable (`ENABLE_ASSET_STATS=true`) or
CLI parameter (`--enable-asset-stats=true`). Please note that it has a negative impact on a DB and ingestion time.
* In ["Offers for Account"](https://www.stellar.org/developers/horizon/reference/endpoints/offers-for-account.html),
`last_modified_time` field  endpoint can be `null` when ledger data is not available (has not been ingested yet).
* ["Trades for Offer"](https://www.stellar.org/developers/horizon/reference/endpoints/trades-for-offer.html) endpoint
will query for trades that match the given offer on either side of trades, rather than just the "sell" offer.
Offer IDs are now [synthetic](https://www.stellar.org/developers/horizon/reference/resources/trade.html#synthetic-offer-ids).
* New `/operation_fee_stats` endpoint includes fee stats for the last 5 ledgers.
* ["Trades"](https://www.stellar.org/developers/horizon/reference/endpoints/trades.html) endpoint can now be streamed.
* In ["Trade Aggregations"](https://www.stellar.org/developers/horizon/reference/endpoints/trade_aggregations.html) endpoint,
`offset` parameter has been added.
* Account flags now display `auth_immutable` value.
* Rate limiting in streams has been changed to be more fair. Now 1 *credit* has to be *paid* every time there's a new ledger
instead of per request.

| Resource                            | Changes                                  | .NET Core SDK |
|:------------------------------------|:-----------------------------------------|:--------------|
| `GET /assets`                       | Disabled by default.                     | ? |
| `GET /accounts/{account_id}/offers` | `last_modified_time` field can be `null` |? |
| `GET /offers/{offer_id}/trades`     | Query fields and syntetic IDs            | ? |
| `GET /trades` SSE                   | Can be streamed                          | ? |
| `GET /operation_fee_stats`          | New endpoint                             | ? |
| `GET /trade_aggregations`           | New `offset` parameter                   | ? |
| `GET /accounts/{account_id}`        | Displaying `auth_immutable` flag         | ? |

### 0.14.0

#### Changes

* New [`bump_sequence`](https://www.stellar.org/developers/horizon/reference/resources/operation.html#bump-sequence) operation.
* New `sequence_bumped` effect.
* New fields in Account > Balances collection: `buying_liabilities` and `selling_liabilities`.
* Offer resource `last_modified` field removed, replaced by `last_modified_ledger` and `last_modified_time`.
* Trade aggregations endpoint accepts only specific time ranges now (1/5/15 minutes, 1 hour, 1 day, 1 week).
* Horizon now sends `Cache-Control: no-cache, no-store, max-age=0` HTTP header for all responses.

| Resource                                    | Changes                                    | .NET Core SDK |
|:--------------------------------------------|:-------------------------------------------|:---------|
| `GET /accounts/{account_id}`                | Liabilities fields in Balances collection. | ? |
| `GET /accounts/{account_id}/effects`        | `sequence_bumped` effect                   | ? |
| `GET /accounts/{account_id}/effects` SSE    | `sequence_bumped` effect                   | ? |
| `GET /accounts/{account_id}/offers`         | `last_modified` field removed              | ? |
| `GET /accounts/{account_id}/operations`     | `bump_sequence` operation                  | ? |
| `GET /accounts/{account_id}/operations` SSE | `bump_sequence` operation                  | ? |
| `GET /effects`                              | `sequence_bumped` effect                   | ? |
| `GET /effects` SSE                          | `sequence_bumped` effect                   | ? |
| `GET /ledgers/{ledger_id}/operations`       | `bump_sequence` operation                  | ? |
| `GET /ledgers/{ledger_id}/operations` SSE   | `bump_sequence` operation                  | ? |
| `GET /ledgers/{ledger_id}/effects`          | `sequence_bumped` effect                   | ? |
| `GET /ledgers/{ledger_id}/effects` SSE      | `sequence_bumped` effect                   | ? |
| `GET /operations`                           | `bump_sequence` operation                  | ? |
| `GET /operations` SSE                       | `bump_sequence` operation                  | ? |
| `GET /operations/{op_id}`                   | `bump_sequence` operation                  | ? |
| `GET /trades_aggregations`                  | Only specific time ranges allowed          | ? |
| `GET /transactions/{tx_id}/operations`      | `bump_sequence` operation                  | ? |
| `GET /transactions/{tx_id}/operations` SSE  | `bump_sequence` operation                  | ? |
| `GET /transactions/{tx_id}/effects`         | `sequence_bumped` effect                   | ? |
| `GET /transactions/{tx_id}/effects` SSE     | `sequence_bumped` effect                   | ? |

### 0.13.0

#### Changes

- `amount` field in `/assets` is now a String (to support Stellar amounts larger than `int64`).
- Effect resource contains a new `created_at` field.

| Resource                                 | Changes                                      | .NET Core SDK |
|:-----------------------------------------|:---------------------------------------------|:--------------|
| `GET /assets`                            | `amount` can be larger than `MAX_INT64`/10^7 | ? |
| `GET /ledgers/{ledger_id}/effects`       | `created_at` field added                     | ? |
| `GET /ledgers/{ledger_id}/effects` SSE   | `created_at` field added                     | ? |
| `GET /accounts/{account_id}/effects`     | `created_at` field added                     | ? |
| `GET /accounts/{account_id}/effects` SSE | `created_at` field added                     | ? |
| `GET /transactions/{tx_id}/effects`      | `created_at` field added                     | ? |
| `GET /transactions/{tx_id}/effects` SSE  | `created_at` field added                     | ? |
| `GET /operations/{op_id}/effects`        | `created_at` field added                     | ? |
| `GET /operations/{op_id}/effects` SSE    | `created_at` field added                     | ? |
| `GET /effects`                           | `created_at` field added                     | ? |
| `GET /effects` SSE                       | `created_at` field added                     | ? |

### 0.12.3

#### Changes

| Resource                                      | .NET Core SDK |
|:----------------------------------------------|:--------------|
| `GET /`                                       | ? |
| `GET /metrics`                                | ? |
| `GET /ledgers`                                | ? |
| `GET /ledgers` SSE                            | ? |
| `GET /ledgers/{ledger_id}`                    | ? |
| `GET /ledgers/{ledger_id}/transactions`       | ? |
| `GET /ledgers/{ledger_id}/transactions` SSE   | ? |
| `GET /ledgers/{ledger_id}/operations`         | ? |
| `GET /ledgers/{ledger_id}/operations` SSE     | ? |
| `GET /ledgers/{ledger_id}/payments`           | ? |
| `GET /ledgers/{ledger_id}/payments` SSE       | ? |
| `GET /ledgers/{ledger_id}/effects`            | ? |
| `GET /ledgers/{ledger_id}/effects` SSE        | ? |
| `GET /accounts/{account_id}`                  | ? |
| `GET /accounts/{account_id}/transactions`     | ? |
| `GET /accounts/{account_id}/transactions` SSE | ? |
| `GET /accounts/{account_id}/operations`       | ? |
| `GET /accounts/{account_id}/operations` SSE   | ? |
| `GET /accounts/{account_id}/payments`         | ? |
| `GET /accounts/{account_id}/payments` SSE     | ? |
| `GET /accounts/{account_id}/effects`          | ? |
| `GET /accounts/{account_id}/effects` SSE      | ? |
| `GET /accounts/{account_id}/offers`           | ? |
| `GET /accounts/{account_id}/trades`           | ? |
| `GET /accounts/{account_id}/data/{key}`       | ? |
| `POST /transactions`                          | ? |
| `GET /transactions`                           | ? |
| `GET /transactions` SSE                       | ? |
| `GET /transactions/{tx_id}`                   | ? |
| `GET /transactions/{tx_id}/operations`        | ? |
| `GET /transactions/{tx_id}/operations` SSE    | ? |
| `GET /transactions/{tx_id}/payments`          | ? |
| `GET /transactions/{tx_id}/payments` SSE      | ? |
| `GET /transactions/{tx_id}/effects`           | ? |
| `GET /transactions/{tx_id}/effects` SSE       | ? |
| `GET /operations`                             | ? |
| `GET /operations` SSE                         | ? |
| `GET /operations/{op_id}`                     | ? |
| `GET /operations/{op_id}/effects`             | ? |
| `GET /operations/{op_id}/effects` SSE         | ? |
| `GET /payments`                               | ? |
| `GET /payments` SSE                           | ? |
| `GET /effects`                                | ? |
| `GET /effects` SSE                            | ? |
| `GET /trades`                                 | ? |
| `GET /trades_aggregations`                    | ? |
| `GET /offers/{offer_id}/trades`               | ? |
| `GET /order_book`                             | ? |
| `GET /order_book` SSE                         | ? |
| `GET /paths`                                  | ? |
| `GET /assets`                                 | ? |


