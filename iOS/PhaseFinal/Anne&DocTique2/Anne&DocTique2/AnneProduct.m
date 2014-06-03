//
//  AnneProduct.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-18.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneProduct.h"

@implementation AnneProduct

+ (instancetype)productWithDictionary:(NSDictionary *)dict {
    AnneProduct *product = [[self alloc] init];
    product.author = dict[@"author"];
    //product.details = dict[@"description"];
    //product.identifier = dict[@"identifier"];
    product.date= dict[@"time"];
    product.votemoins = dict[@"votemoins"];
    product.voteplus = dict[@"voteplus"];
    if (dict[@"imageURL"]) {
        product.imageURL = dict[@"imageURL"];
    } else if (dict[@"imageURLString"]) {
        product.imageURL = [NSURL URLWithString:dict[@"imageURLString"]];
    }
    return product;
}

+ (NSArray *)productsWithArray:(NSArray *)array {
    NSMutableArray *products = [NSMutableArray arrayWithCapacity:[array count]];
    for (NSDictionary *dict in array) {
        AnneProduct *product = [self productWithDictionary:dict];
        [products addObject:product];
    }
    return products;
}
@end
