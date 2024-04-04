import type { Entry, NewEntry } from './entry'

type NewTransaction = {
  date: Date
}

type Transaction = {
  id: number
  date: Date
  entries: (Entry | NewEntry)[]
}

export type { NewTransaction, Transaction }
