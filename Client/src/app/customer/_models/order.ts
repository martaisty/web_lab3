export interface Order {
  books?: OrderBook[];
}

export interface OrderBook {
  bookId?: string;
  quantity?: number;
}
