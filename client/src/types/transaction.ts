import type { Entry } from './entry'

type NewTransaction = {
  date: Date
}

type Transaction = {
  id: number
  date: Date
  entries: Entry[]
}

export type { NewTransaction, Transaction }
