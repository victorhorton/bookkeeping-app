import type { Transaction } from './transaction'

type NewBatch = {
  name: string
  status: number
}

type Batch = {
  id: number
  name: string
  status: number
  transactions: Transaction[]
}

export type { NewBatch, Batch }
