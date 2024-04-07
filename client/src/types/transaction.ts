import type { Entry, NewEntry } from './entry'

type NewTransaction = {
  date: Date
  companyId: number
}

type Transaction = {
  id: number
  date: Date
  companyId: number
  entries: (Entry | NewEntry)[]
}

export type { NewTransaction, Transaction }
